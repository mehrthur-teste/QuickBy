import { Component, OnInit } from '@angular/core'
import { Produto } from '../../modelo/produto';
import { ProdutoServico } from '../../../servicos/produto/produto.service';
import { Router } from '@angular/router';
import { LojaCarrinhoCompras } from '../carrinho-compras/loja.carrinho.compras';
import { Pedido } from '../../modelo/Pedido';
import { UsuarioServico } from 'src/servicos/usuario/usuario.service';
import { ItemPedido } from 'src/app/modelo/itemPedido';
import { PedidoServico } from '../../../servicos/pedido/pedido.servico';


@Component({
  selector: "loja-efetivar",
  templateUrl: "./loja.efetivar.component.html",
  styleUrls: ["./loja.efetivar.component.css"]
})
export class LojaEfetivarComponent implements OnInit {

  public carrinhoCompras: LojaCarrinhoCompras;
  public produtos: Produto[];
  public total: number;

  ngOnInit(): void {
    this.carrinhoCompras = new LojaCarrinhoCompras();
    this.produtos = this.carrinhoCompras.obterProdutos();
    this.atualizarTotal();
  }

  constructor(private UsuarioServico: UsuarioServico,
    private pedidoServico: PedidoServico,
    private router: Router) {

  }

  public atualizarPreco(produto: Produto, quantidade: number) {

    if (!produto.precoOriginal) {
      produto.precoOriginal = produto.preco;
    }


    // para fazer com que o front só permita quantidade da regra de negócio
    if (quantidade <= 0) {
      quantidade = 1;
      produto.quantidade = quantidade;
    }

    produto.preco = produto.precoOriginal * quantidade;
    this.carrinhoCompras.atualizar(this.produtos);
    this.atualizarTotal();
  }

  public remover(produto: Produto) {
    this.carrinhoCompras.removerProduto(produto);
    this.produtos = this.carrinhoCompras.obterProdutos();
    this.atualizarTotal();
  }

  public atualizarTotal() {
    this.total = this.produtos.reduce((acc, produto) => acc + produto.preco, 0);
  }

  
  public efetivarCompra() {
    let pedido = this.criarPedido();//new Pedido();
    this.pedidoServico.efetivarCompra(pedido).subscribe(
      pedidoId => {
        console.log(pedidoId);
        sessionStorage.setItem("pedidoId", pedidoId.toString());
        this.produtos = [];
        this.carrinhoCompras.limparCarrinhoCompras();
        // redirecionar para outra página
        this.router.navigate(["/compra-realizada-sucesso"]);
      },
      e => {
        console.log(e.error);
      }
    );
  }


  public criarPedido(): Pedido {
    let pedido = new Pedido();
    //dados fakes
    pedido.UsuarioId = this.UsuarioServico.usuario.id;
    pedido.CEP = "122323";
    pedido.Cidade = "São Paulo";
    //pedido.DataPedido = new Date();
    pedido.DatePrevisaoEntrega = new Date();
    pedido.FormaPagamentoId = 1;
    pedido.NumeroEndereco = 33;
    pedido.EnderecoCompleto = "Rua Major Diogo";
    pedido.Estado = "SP";
    this.produtos = this.carrinhoCompras.obterProdutos();

    for (let produto of this.produtos) {
      let itemPedido = new ItemPedido();
      itemPedido.ProdutoId = produto.id;
      itemPedido.Quantidade = produto.quantidade;

      if (!produto.quantidade)
        produto.quantidade = 1;
      itemPedido.Quantidade = produto.quantidade;
      pedido.itensPedido.push(itemPedido);
    }
    return pedido;
  }


}

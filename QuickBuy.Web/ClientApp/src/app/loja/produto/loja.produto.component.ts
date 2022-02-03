import { Component, OnInit } from '@angular/core'
import { ProdutoServico } from '../../../servicos/produto/produto.service';
import { Produto } from '../../modelo/produto';
import { Router } from '@angular/router';
import { LojaCarrinhoCompras } from '../carrinho-compras/loja.carrinho.compras';

@Component({
  selector: "loja-app-produto",
  templateUrl: "./loja.produto.component.html",
  styleUrls: ["./loja.produto.component.css"]
})

export class LojaProdutoComponent implements OnInit {
  produto: Produto;
  public carrinhoCompras: LojaCarrinhoCompras;

  ngOnInit(): void {
    this.carrinhoCompras = new LojaCarrinhoCompras();
    var ProdutoDetalhe = sessionStorage.getItem('produtoDetalhe');
    if (ProdutoDetalhe) {
      this.produto = JSON.parse(ProdutoDetalhe);
    }
  }

  constructor(private produtoServico:ProdutoServico,private router:Router) {

  }

  comprar(): void{
    this.carrinhoCompras.adicionar(this.produto);
    this.router.navigate(["/loja-efetivar"]);
  }


}


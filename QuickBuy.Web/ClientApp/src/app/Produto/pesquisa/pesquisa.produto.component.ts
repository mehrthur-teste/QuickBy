import { Component,OnInit } from '@angular/core';
import { Produto } from '../../modelo/Produto';
import { ProdutoServico } from '../../../servicos/produto/produto.service';
import { Router } from '@angular/router';

@Component({

    selector: "pesquisa-produto",
    templateUrl: "./pesquisa.produto.component.html",
    styleUrls:["./pesquisa.produto.component.css"]

})

export class PesquisaProdutoComponent implements OnInit {

    public produtos: Produto[];
    ngOnInit(): void {

    }



    constructor(private produtoServico: ProdutoServico, private router: Router) {
        this.produtoServico.obterTodosProdutos()
            .subscribe(
                produtos => {
                    this.produtos = produtos;
                },
                e => {
                    console.log(e.error);
                }
            );
    }

    public adicionarProduto() {
        sessionStorage.setItem('produtoSession',"");
        this.router.navigate(['/produto']);
    }

    public deletarProduto(produto: Produto) {
        var retorno = confirm("Deseja realmente deletar o produto?");
        if (retorno == true) {
            this.produtoServico.deletar(produto)
                .subscribe(
                    produtos => {
                        this.produtos = produtos;
                       
                    },
                    e => {
                        console.log(e.error);
                    }
                );

        }
    }

    public editarProduto(produto: Produto) {

        // armazenar o produto que foi selecionado pelo usuario convertido em json
        sessionStorage.setItem('produtoSession', JSON.stringify(produto));
        this.router.navigate(['/produto']);
    }
}

"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.LojaCarrinhoCompras = void 0;
var LojaCarrinhoCompras = /** @class */ (function () {
    function LojaCarrinhoCompras() {
        this.produtos = [];
    }
    LojaCarrinhoCompras.prototype.adicionar = function (produto) {
        var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
        //se não existir nada no storage
        if (!produtoLocalStorage) {
            this.produtos.push(produto);
        }
        else {
            //se já existir pelo menos um item na sessão
            this.produtos = JSON.parse(produtoLocalStorage);
            this.produtos.push(produto);
        }
        localStorage.setItem("produtoLocalStorage", JSON.stringify(this.produtos));
    };
    LojaCarrinhoCompras.prototype.obterProdutos = function () {
        //produtoLocalStorage
        var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
        //retornar do local storage
        if (produtoLocalStorage) {
            return JSON.parse(produtoLocalStorage);
        }
        return this.produtos;
    };
    LojaCarrinhoCompras.prototype.removerProduto = function (produto) {
        var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
        if (produtoLocalStorage) {
            this.produtos = JSON.parse(produtoLocalStorage);
            this.produtos = this.produtos.filter(function (p) { return p.id != produto.id; }); //esse campo de pesquisa pode mudar tá dando conflito
            localStorage.setItem("produtoLocalStorage", JSON.stringify(this.produtos));
        }
    };
    LojaCarrinhoCompras.prototype.atualizar = function (produtos) {
        localStorage.setItem("produtoLocalStorage", JSON.stringify(produtos));
    };
    LojaCarrinhoCompras.prototype.temItensCarrinhoCompras = function () {
        var itens = this.obterProdutos();
        return (itens.length > 0);
    };
    LojaCarrinhoCompras.prototype.limparCarrinhoCompras = function () {
        localStorage.setItem("produtoLocalStorage", "");
    };
    return LojaCarrinhoCompras;
}());
exports.LojaCarrinhoCompras = LojaCarrinhoCompras;
//# sourceMappingURL=loja.carrinho.compras.js.map
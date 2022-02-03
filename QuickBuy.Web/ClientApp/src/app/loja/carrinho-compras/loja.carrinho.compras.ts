import { Produto } from "../../modelo/produto";


export class LojaCarrinhoCompras {


  public produtos: Produto[] = [];

  public adicionar(produto: Produto) {
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
  }

  public obterProdutos(): Produto[] {
    //produtoLocalStorage
    var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
    //retornar do local storage
    if (produtoLocalStorage) {
      return JSON.parse(produtoLocalStorage);
    }
    return this.produtos;
  }

  public removerProduto(produto: Produto) {
    var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
    if (produtoLocalStorage) {
      this.produtos = JSON.parse(produtoLocalStorage);
      this.produtos = this.produtos.filter(p => p.id != produto.id); //esse campo de pesquisa pode mudar tá dando conflito
      localStorage.setItem("produtoLocalStorage", JSON.stringify(this.produtos));
    }
  }

  public atualizar(produtos: Produto[]) {
    localStorage.setItem("produtoLocalStorage", JSON.stringify(produtos));
  }

  public temItensCarrinhoCompras(): boolean {
    var itens = this.obterProdutos();
    return (itens.length > 0)
  }

  public limparCarrinhoCompras() {
    localStorage.setItem("produtoLocalStorage", "");
  }


}

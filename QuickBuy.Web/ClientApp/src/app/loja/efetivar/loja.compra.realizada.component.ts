import { Component, OnInit } from '@angular/core'

@Component({
  //selector: "loja-efetivar",
  templateUrl: "loja.compra.realizada.component.html",
  //styleUrls: ["./loja.efetivar.component.css"]
})

export class LojaCompraRealizada implements OnInit {

  public pedidoId: string;
  ngOnInit(): void{
    this.pedidoId = sessionStorage.getItem("pedidoId");
  }
  

}

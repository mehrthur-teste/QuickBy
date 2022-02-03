import { ItemPedido } from "./itemPedido";

export class Pedido {

  public Id: number;

  public DataPedido: Date;

  public UsuarioId: number;

  public DatePrevisaoEntrega: Date;

  public CEP: string;

  public Estado: string;

  public Cidade: string;

  public EnderecoCompleto: string;

  public NumeroEndereco: number;

  public FormaPagamentoId: number;
  public itensPedido: ItemPedido[];

  constructor() {
    this.DataPedido = new Date();
    this.itensPedido = [];
  }


}

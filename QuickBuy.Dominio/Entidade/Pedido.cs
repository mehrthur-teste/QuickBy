using Quickbuy.Dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quickbuy.Dominio.Entidade
{
    public class Pedido : Entidade
    {
        public int Id { get; set; }

        public DateTime DataPedido { get; set; }

        public int UsuarioId { get; set; }

        public virtual Usuarios Usuario { get; set; }

        public DateTime DatePrevisaoEntrega { get; set; }

        public string CEP { get; set; }

        public string Estado { get; set; }

        public string Cidade { get; set; }

        public string EnderecoCompleto { get; set; }

        public int NumeroEndereco    { get; set; }

        public int FormaPagamentoId { get; set; }

        public virtual FormaPagamento FormaPagamento { get; set; }



        /// <summary>
        /// Pedido deve ter pelo menos um pedido ou muitos pedidos
        /// </summary>

        public virtual ICollection<ItemPedido> ItensPedidos { get; set; }

       
        public override void Validate()
        {
            LimparMensagemValidacao();

            if (ItensPedidos.Any())
                AdicionarCritica("Critica - Pedido não ficar sem item de pedido");
            
            if (string.IsNullOrEmpty(CEP))
                AdicionarCritica("Critica - Cep deve estar preenchido");

            if (FormaPagamentoId==0)
                AdicionarCritica("Critica - Cep deve estar preenchido");
        }
    }
}

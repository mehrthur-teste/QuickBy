using System;
using System.Collections.Generic;
using System.Text;

namespace Quickbuy.Dominio.Entidade
{
   public class ItemPedido :Entidade
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }

        public int Quantidade { get; set; }

        public override void Validate()
        {
            if (ProdutoId == 0)
                AdicionarCritica("Não foi identificado qual a referencia");

            if (Quantidade == 0)
                AdicionarCritica("A quantidade não foi informada");
        }
    }
}

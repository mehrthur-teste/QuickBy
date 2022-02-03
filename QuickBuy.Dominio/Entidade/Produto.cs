 using System;
using System.Collections.Generic;
using System.Text;

namespace Quickbuy.Dominio.Entidade
{
   public class Produto :Entidade
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }

        public string NomeArquivo { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Nome))
                AdicionarCritica("Critica - Nome deve estar preenchido");

            if (string.IsNullOrEmpty(Descricao))
                AdicionarCritica("Critica - Descrição deve estar preenchido ");

            if (Preco == 0)
                AdicionarCritica("Critica - Preço deve estar preenchido");

        }
    }
}

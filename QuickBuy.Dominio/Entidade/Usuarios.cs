
using System.Collections.Generic;

namespace Quickbuy.Dominio.Entidade
{
   public  class Usuarios :Entidade
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public bool EhAdministrador { get; set; }

        /// <summary>
        /// Um Usuario Pode ter nenhum ou muitos pedidos 
        /// </summary>
        
        public virtual ICollection<Pedido>  Pedidos { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Email))
                AdicionarCritica("Critica - Email deve estar preenchido");

            if (string.IsNullOrEmpty(Senha))
                AdicionarCritica("Critica - Senha deve estar preenchido");
        }
    }
}

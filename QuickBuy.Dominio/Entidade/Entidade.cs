using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quickbuy.Dominio.Entidade
{
    public abstract   class  Entidade
    {
        private List<string> _menagensValidacao {get; set;}

        private List<string> MensagemValidacao 
        {
            get { return _menagensValidacao ?? (_menagensValidacao = new List<string>()); }
        }


        protected void LimparMensagemValidacao()
        {

            MensagemValidacao.Clear();
        }

        protected void AdicionarCritica(string mensagem)
        {

            MensagemValidacao.Add(mensagem);
        }

        public string ObterMensagensValidacao() 
        {
            return string.Join(". ",MensagemValidacao);
        }

        public abstract void Validate();

        public bool EhValido 
        {
            get { return !MensagemValidacao.Any() ; }
        }
    }
}

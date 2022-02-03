using Quickbuy.Dominio.Contratos;
using Quickbuy.Dominio.Entidade;
using QuickBuy.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.Repositorio.Repositorios
{
    public class UsuarioRepositorio : BaseRepositorios<Usuarios>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(QuickBuyContexto quickBuyContexto) : base(quickBuyContexto)
        {
        }

        public Usuarios Obter(string email, string senha)
        {
            return QuickBuyContexto.Usuarios.FirstOrDefault(
                                                             u => u.Email == email && u.Senha == senha);
        }

        public Usuarios Obter(string email)
        {
            return QuickBuyContexto.Usuarios.FirstOrDefault(
                u =>
                    u.Email==email
             );
        }
    }
}

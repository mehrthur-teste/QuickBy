using Quickbuy.Dominio.Entidade;

namespace Quickbuy.Dominio.Contratos
{
    public interface IUsuarioRepositorio  :  IBaseRepositorio<Usuarios>
    {
        Usuarios Obter(string email,string senha);
        Usuarios Obter(string email);
    }
}

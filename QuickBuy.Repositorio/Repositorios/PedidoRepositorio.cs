using Quickbuy.Dominio.Contratos;
using Quickbuy.Dominio.Entidade;
using QuickBuy.Repositorio.Contexto;

namespace QuickBuy.Repositorio.Repositorios
{
    public class PedidoRepositorio : BaseRepositorios<Pedido>, IPedidoRepositorio
    {
        public PedidoRepositorio(QuickBuyContexto quickBuyContexto) : base(quickBuyContexto)
        {
        }
    }
}

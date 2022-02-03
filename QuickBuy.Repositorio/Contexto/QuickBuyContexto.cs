

using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Quickbuy.Dominio.Entidade;
using Quickbuy.Dominio.ObjetoDeValor;
using QuickBuy.Repositorio.Config;

namespace QuickBuy.Repositorio.Contexto
{
   public class QuickBuyContexto :DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }

        public QuickBuyContexto(DbContextOptions options) : base(options)
        {
            

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            /// Classes de mapeamento aqui
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
            modelBuilder.ApplyConfiguration(new FormaPagamentoConfiguration());
            modelBuilder.Entity<FormaPagamento>().HasData(
                new FormaPagamento
                {
                Id=1,
                Nome="Boleto",
                Descricao= "Forma de Pagamento Boleto",
                },
                new FormaPagamento
                {
                Id = 2,
                Nome = "Credito",
                Descricao = "Forma de Pagamento Cartão de Crédito",
                },
                new FormaPagamento
                {
                Id = 3,
                Nome = "Deposito",
                Descricao = "Forma de Pagamento Depósito",
                }
                                                         );

            base.OnModelCreating(modelBuilder);
        }

    }
}

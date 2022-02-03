using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quickbuy.Dominio.Entidade;

namespace QuickBuy.Repositorio.Config
{
    public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            //adicionar chave primária
            builder.HasKey(i => i.Id);

            //builder usa o padrão fluent para mostrar que ele é requerido e que o máximo dele é 50
            builder
                .Property(i => i.ProdutoId)
                .IsRequired();

            builder
                  .Property(i => i.Quantidade)
                  .IsRequired();

        }
    }
}

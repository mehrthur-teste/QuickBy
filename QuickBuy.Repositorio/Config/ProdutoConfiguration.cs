using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quickbuy.Dominio.Entidade;

namespace QuickBuy.Repositorio.Config
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            //adicionar chave primária
            builder.HasKey(p => p.Id);

            //builder usa o padrão fluent para mostrar que ele é requerido e que o máximo dele é 50
            builder
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder
                  .Property(p => p.Descricao)
                  .IsRequired()
                  .HasMaxLength(500);

            builder
                .Property(p => p.Preco)
                .HasColumnType("decimal(19,4)")
                .IsRequired();


           
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quickbuy.Dominio.ObjetoDeValor;

namespace QuickBuy.Repositorio.Config
{
    public class FormaPagamentoConfiguration : IEntityTypeConfiguration<FormaPagamento>
    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
            //adicionar chave primária
            builder.HasKey(f => f.Id);

            //builder usa o padrão fluent para mostrar que ele é requerido e que o máximo dele é 50
            builder
                .Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder
                  .Property(f => f.Descricao)
                  .IsRequired()
                  .HasMaxLength(100);

        }
    }
}

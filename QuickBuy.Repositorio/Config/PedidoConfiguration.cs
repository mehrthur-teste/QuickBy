using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quickbuy.Dominio.Entidade;

namespace QuickBuy.Repositorio.Config
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            //adicionar chave primária
            builder.HasKey(p => p.Id);

            //builder usa o padrão fluent para mostrar que ele é requerido e que o máximo dele é 50
            builder
                .Property(p => p.DataPedido)
                .IsRequired();

            builder
                  .Property(p => p.UsuarioId)
                  .IsRequired();

            builder
                .Property(p => p.DatePrevisaoEntrega)
                .IsRequired();


            builder
                .Property(p => p.CEP)
                .IsRequired()
                .HasMaxLength(10);

            builder
               .Property(p => p.Estado)
               .IsRequired()
               .HasMaxLength(100);

            builder
               .Property(p => p.Cidade)
               .IsRequired()
               .HasMaxLength(100);

            builder
               .Property(p => p.EnderecoCompleto)
               .IsRequired()
               .HasMaxLength(100);

            builder
               .Property(p => p.NumeroEndereco)
               .IsRequired()
               .HasMaxLength(50);
            /*
             * 
              builder
               .Property(p => p.FormaPagamentoId)
               .IsRequired()
               .HasMaxLength(50);

                builder
                   .Property(p => p.FormaPagamento)
                   .IsRequired()
                   .HasMaxLength(50);
             * 
             */
            // builder.HasOne(p=>p.Usuario);

            builder.HasOne(p => p.FormaPagamento);
            
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quickbuy.Dominio.Entidade;

namespace QuickBuy.Repositorio.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            //adicionar chave primária
            builder.HasKey(u => u.Id);

            //builder usa o padrão fluent para mostrar que ele é requerido e que o máximo dele é 50
            builder
                .Property(u =>u.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder
                  .Property(u => u.Nome)
                  .IsRequired()
                  .HasMaxLength(50);

            builder
                .Property(u => u.SobreNome)
                .IsRequired()
                .HasMaxLength(50);


            builder
                .Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(400);
            
            // aqui está a se dizer que pediso só pode estar configurado a um unico usuario
            //informando que outro usuario não pode se relacionar
            builder
               .HasMany(u => u.Pedidos)
               .WithOne(p=>p.Usuario);

        }
    }
}

using devRank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace devRank.Infra.Data.Maps;

public class UsuarioMap : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable(nameof(Usuario));

        builder.HasKey(us => us.Id);
        builder.Property(us => us.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(us => us.Nome)
            .HasMaxLength(250);

        builder.Property(us => us.Email)
            .HasMaxLength(350);

        builder.HasOne(us => us.Perfil)
            .WithMany(pf => pf.Usuario)
            .HasForeignKey(us => us.PerfilId);
    }
}
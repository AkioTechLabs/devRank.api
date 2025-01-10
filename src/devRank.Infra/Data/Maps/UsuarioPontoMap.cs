using devRank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace devRank.Infra.Data.Maps;

public class UsuarioPontoMap : IEntityTypeConfiguration<UsuarioPonto>
{
    public void Configure(EntityTypeBuilder<UsuarioPonto> builder)
    {
        builder.ToTable(nameof(UsuarioPonto));

        builder.HasKey(us => us.Id);
        builder.Property(us => us.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(us => us.Observacao)
            .HasMaxLength(1000);

        builder.HasOne(us => us.Usuario)
            .WithMany(pf => pf.UsuarioPonto)
            .HasForeignKey(us => us.UsuarioId);
    }
}
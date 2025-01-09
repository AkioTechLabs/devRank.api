using devRank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace devRank.Infra.Data.Maps;

public class PerfilPermissaoMap : IEntityTypeConfiguration<PerfilPermissao>
{
    public void Configure(EntityTypeBuilder<PerfilPermissao> builder)
    {
        builder.ToTable(nameof(PerfilPermissao));

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.HasOne(pp => pp.Perfil)
            .WithMany(pf => pf.PerfilPermissao)
            .HasForeignKey(pp => pp.PerfilId);

        builder.HasOne(pp => pp.Permissao)
            .WithMany(pf => pf.PerfilPermissao)
            .HasForeignKey(pp => pp.PermissaoId);
    }
}
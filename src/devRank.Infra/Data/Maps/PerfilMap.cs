using devRank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace devRank.Infra.Data.Maps;

public class PerfilMap : IEntityTypeConfiguration<Perfil>
{
    public void Configure(EntityTypeBuilder<Perfil> builder)
    {
        builder.ToTable(nameof(Perfil));

        builder.HasKey(pf => pf.Id);
        builder.Property(pf => pf.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

        builder.Property(pf => pf.Descricao)
            .HasMaxLength(100);
    }
}
using devRank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace devRank.Infra.Data.Maps;

public class PermissaoMap : IEntityTypeConfiguration<Permissao>
{
    public void Configure(EntityTypeBuilder<Permissao> builder)
    {
        builder.ToTable(nameof(Permissao));

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever();

        builder.Property(x => x.Descricao)
            .HasMaxLength(150);
    }
}
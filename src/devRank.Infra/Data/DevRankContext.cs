using devRank.Domain.Contracts.Repositories;
using devRank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace devRank.Infra.Data;

public class DevRankContext(DbContextOptions<DevRankContext> options) :
    DbContext(options),
    IUnitOfWork
{
    #region DbSet

    public DbSet<Perfil> Perfil { get; set; }
    public DbSet<PerfilPermissao> PerfilPermissao { get; set; }
    public DbSet<Permissao> Permissao { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
    
    #endregion DbSet

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DevRankContext).Assembly);
    }
}
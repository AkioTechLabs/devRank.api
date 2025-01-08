using devRank.Domain.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace devRank.Infra.Data;

public class DevRankContext(DbContextOptions<DevRankContext> options) :
    DbContext(options),
    IUnitOfWork
{
    #region DbSet

    #endregion DbSet

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DevRankContext).Assembly);
    }
}
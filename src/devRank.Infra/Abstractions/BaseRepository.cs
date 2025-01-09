using devRank.Domain.Abstractions;
using devRank.Domain.Abstractions.Contracts;
using devRank.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace devRank.Infra.Abstractions;

public class BaseRepository<TEntity>(DevRankContext context)
    : IBaseRepository<TEntity>
    where TEntity : Entity
{
    public TEntity Inserir(
        TEntity entity)
    {
        context
            .Set<TEntity>()
            .Add(entity);

        return entity;
    }

    public TEntity Atualizar(
        TEntity entity)
    {
        context
            .Set<TEntity>()
            .Update(entity);

        return entity;
    }

    public async Task<TEntity?> ObterPorId(
        long id,
        CancellationToken cancellationToken)
    {
        TEntity? entity = await context
            .Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        return entity;
    }
}
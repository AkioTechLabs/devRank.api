using devRank.Domain.Abstractions.Contracts;
using devRank.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Nature.Domain.Abstractions;

namespace devRank.Infra.Abstractions;

public class BaseRepository<TEntity>(DevRankContext context)
    : IBaseRepository<TEntity>
    where TEntity : Entity
{
    public TEntity Inserir(
        TEntity entity,
        CancellationToken cancellationToken)
    {
        context
            .Set<TEntity>()
            .Add(entity);

        return entity;
    }

    public TEntity Atualizar(
        TEntity entity,
        CancellationToken cancellationToken)
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
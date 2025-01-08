using Nature.Domain.Abstractions;

namespace devRank.Domain.Abstractions.Contracts;

public interface IBaseRepository<TEntity> : IRepository
    where TEntity : Entity
{
    TEntity Inserir(TEntity entity, CancellationToken cancellationToken);
    TEntity Atualizar(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity?> ObterPorId(long id, CancellationToken cancellationToken);
}
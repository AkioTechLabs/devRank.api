namespace devRank.Domain.Abstractions.Contracts;

public interface IBaseRepository<TEntity> : IRepository
    where TEntity : Entity
{
    TEntity Inserir(TEntity entity);
    TEntity Atualizar(TEntity entity);
    Task<TEntity?> ObterPorId(long id, CancellationToken cancellationToken);
}
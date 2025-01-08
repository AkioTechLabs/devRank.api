using devRank.Domain.Abstractions.Contracts;

namespace devRank.Domain.Contracts.Repositories;

public interface IUnitOfWork : IRepository
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
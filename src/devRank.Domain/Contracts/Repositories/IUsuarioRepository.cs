using devRank.Domain.Abstractions.Contracts;
using devRank.Domain.Entities;

namespace devRank.Domain.Contracts.Repositories;

public interface IUsuarioRepository : IBaseRepository<Usuario>
{
    Task<Usuario?> ObterPorEmail(string email, CancellationToken cancellationToken);
    Task<Usuario?> ObterPorIdComDependencias(long id, CancellationToken cancellationToken);
}
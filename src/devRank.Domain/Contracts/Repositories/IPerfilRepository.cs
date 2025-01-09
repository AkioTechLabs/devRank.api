using devRank.Domain.Abstractions.Contracts;
using devRank.Domain.Entities;
using devRank.Shared.Dtos.Perfil;

namespace devRank.Domain.Contracts.Repositories;

public interface IPerfilRepository : IBaseRepository<Perfil>
{
    Task<PerfilDto?> ObterPorIdDependencias(long id, CancellationToken cancellationToken);
}
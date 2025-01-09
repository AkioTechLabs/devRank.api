using devRank.Domain.Abstractions.Contracts;
using devRank.Domain.Entities;

namespace devRank.Domain.Contracts.Repositories;

public interface IPermissaoRepository : IBaseRepository<Permissao>
{
    Task<List<Permissao>> ObterTodasPermissoes(CancellationToken cancellationToken);
    Task<List<long>> ValidarExistentes(List<long> ids, CancellationToken cancellationToken);
}
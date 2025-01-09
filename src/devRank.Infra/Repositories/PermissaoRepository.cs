using devRank.Domain.Contracts.Repositories;
using devRank.Domain.Entities;
using devRank.Infra.Abstractions;
using devRank.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace devRank.Infra.Repositories;

public class PermissaoRepository(DevRankContext context) : 
    BaseRepository<Permissao>(context), 
    IPermissaoRepository
{
    public async Task<List<Permissao>> ObterTodasPermissoes(CancellationToken cancellationToken)
    {
        return await context.Permissao
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<List<long>> ValidarExistentes(List<long> ids, CancellationToken cancellationToken)
    {
        List<long> idsExistentes = await context.Permissao
            .AsNoTracking()
            .Where(p => ids.Contains(p.Id))
            .Select(p => p.Id)
            .ToListAsync(cancellationToken);

        List<long> idsNaoExistentes = ids
            .Except(idsExistentes)
            .ToList();

        return idsNaoExistentes;
    }
}
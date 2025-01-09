using devRank.Domain.Contracts.Repositories;
using devRank.Domain.Entities;
using devRank.Infra.Abstractions;
using devRank.Infra.Data;
using devRank.Shared.Dtos.Perfil;
using Microsoft.EntityFrameworkCore;

namespace devRank.Infra.Repositories;

public class PerfilRepository(DevRankContext context) :
    BaseRepository<Perfil>(context),
    IPerfilRepository
{
    public async Task<PerfilDto?> ObterPorIdDependencias(
        long id,
        CancellationToken cancellationToken)
    {
        var perfil = await context.Perfil
            .AsNoTracking()
            .Include(pf => pf.PerfilPermissao)
            .ThenInclude(pp => pp.Permissao)
            .FirstOrDefaultAsync(pf => pf.Id == id, cancellationToken);

        if (perfil == null)
            return null;

        var perfilDto = new PerfilDto(
            perfil.Id,
            perfil.Descricao,
            perfil.PerfilPermissao
                .Select(pp => new PerfilPermissaoDto(
                    pp.PermissaoId,
                    pp.Permissao!.Descricao
                ))
                .ToList()
        );

        return perfilDto;
    }
}
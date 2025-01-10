using devRank.Domain.Contracts.Repositories;
using devRank.Domain.Entities;
using devRank.Infra.Abstractions;
using devRank.Infra.Data;
using devRank.Shared.Dtos.Filters;
using devRank.Shared.Dtos.UsuarioPonto;
using devRank.Shared.Enums.Usuario;
using FastResults.Extensions;
using Microsoft.EntityFrameworkCore;

namespace devRank.Infra.Repositories;

public class UsuarioPontoRepository(DevRankContext context) :
    BaseRepository<UsuarioPonto>(context),
    IUsuarioPontoRepository
{
    public async Task<List<UsuarioPontoDto>> ObterPontosPorData(
        DateTime dataInicial,
        DateTime dataFinal,
        CancellationToken cancellationToken)
    {
        return await context.UsuarioPonto
            .AsNoTracking()
            .Where(up => up.DataCriacao.Date >= dataInicial
                         && up.DataCriacao.Date <= dataFinal
                         && up.Usuario.Avaliado
                         && up.Ativo)
            .GroupBy(up => new { up.UsuarioId, up.Usuario.Nome })
            .Select(up => new UsuarioPontoDto(
                up.Key.UsuarioId,
                up.Key.Nome,
                up.Sum(us => us.Movimento == TipoMovimento.Ganhar
                    ? us.Ponto
                    : (us.Movimento == TipoMovimento.Perder ? -us.Ponto : 0)),
                0))
            .ToListAsync(cancellationToken);
    }

    public async Task<UsuarioPontoCompletoDto?> ObterPorUsuario(
        ObterUsuarioPontoPorFiltroDto filtro,
        CancellationToken cancellationToken)
    {
        return await context.UsuarioPonto
            .AsNoTracking()
            .Where(up => up.DataCriacao.Date >= filtro.DataInicial
                         && up.DataCriacao.Date <= filtro.DataFinal
                         && up.UsuarioId == filtro.Id
                         && up.Usuario.Avaliado
                         && up.Ativo)
            .GroupBy(up => new { up.UsuarioId, up.Usuario.Nome })
            .Select(up => new UsuarioPontoCompletoDto(
                new UsuarioPontoDto(
                    up.Key.UsuarioId,
                    up.Key.Nome,
                    up.Sum(us => us.Movimento == TipoMovimento.Ganhar
                        ? us.Ponto
                        : (us.Movimento == TipoMovimento.Perder ? -us.Ponto : 0)),
                    0),
                up.Select(uh => new UsuarioPontoHistoricoDto(
                    uh.Id,
                    uh.Observacao,
                    uh.Ponto,
                    (int)uh.Movimento,
                    uh.Tipo,
                    uh.Tipo.GetDescription(),
                    uh.DataCriacao
                )).ToList())
            )
            .FirstOrDefaultAsync(cancellationToken);
    }
}
using devRank.Domain.Abstractions.Contracts;
using devRank.Domain.Entities;
using devRank.Shared.Dtos.Filters;
using devRank.Shared.Dtos.UsuarioPonto;

namespace devRank.Domain.Contracts.Repositories;

public interface IUsuarioPontoRepository : IBaseRepository<UsuarioPonto>
{
    Task<List<UsuarioPontoDto>> ObterPontosPorData(DateTime dataInicial, DateTime dataFinal,
        CancellationToken cancellationToken);

    Task<UsuarioPontoCompletoDto?> ObterPorUsuario(ObterUsuarioPontoPorFiltroDto filtro ,CancellationToken cancellationToken);
}
using devRank.Application.Abstractions;
using devRank.Application.Requests.UsuarioPonto;
using devRank.Application.Responses.UsuarioPonto;
using devRank.Domain.Contracts.Repositories;
using devRank.Shared.Extensions;
using FastResults.Results;
using Mapster;
using MediatR;

namespace devRank.Application.UseCases.UsuarioPontoUseCase;

public class ObterUsuarioPontoUseCase(
    ISender sender,
    IUsuarioPontoRepository usuarioPontoRepository) :
    BaseUseCase<
        ObterUsuarioPontoRequest,
        List<UsuarioPontoResponse>>(sender)
{
    public override async Task<BaseResult<List<UsuarioPontoResponse>>> Handle(
        ObterUsuarioPontoRequest request,
        CancellationToken cancellationToken)
    {
        var pontos = await usuarioPontoRepository.ObterPontosPorData(
            request.DataInicial,
            request.DataFinal,
            cancellationToken);
        if (!pontos.Any())
        {
            return BaseResultExtension<List<UsuarioPontoResponse>>.NenhumRegistro;
        }

        return pontos.Adapt<List<UsuarioPontoResponse>>();
    }
}
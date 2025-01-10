using devRank.Application.Abstractions;
using devRank.Application.Requests.UsuarioPonto;
using devRank.Application.Responses.UsuarioPonto;
using devRank.Domain.Contracts.Repositories;
using devRank.Shared.Dtos.Filters;
using devRank.Shared.Extensions;
using FastResults.Results;
using Mapster;
using MediatR;

namespace devRank.Application.UseCases.UsuarioPontoUseCase;

public class ObterUsuarioPontoPorUsuarioUseCase(
    ISender sender,
    IUsuarioPontoRepository usuarioPontoRepository) :
    BaseUseCase<
        ObterUsuarioPontoPorUsuarioRequest,
        UsuarioPontoCompletoResponse>(sender)
{
    public override async Task<BaseResult<UsuarioPontoCompletoResponse>> Handle(
        ObterUsuarioPontoPorUsuarioRequest request,
        CancellationToken cancellationToken)
    {
        var usuario = await usuarioPontoRepository.ObterPorUsuario(
            request.Adapt<ObterUsuarioPontoPorFiltroDto>(),
            cancellationToken);
        if (usuario is null)
        {
            return BaseResultExtension<UsuarioPontoCompletoResponse>.NenhumRegistro;
        }

        return usuario.Adapt<UsuarioPontoCompletoResponse>();
    }
}
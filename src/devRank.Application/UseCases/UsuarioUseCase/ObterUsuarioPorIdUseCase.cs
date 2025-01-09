using devRank.Application.Abstractions;
using devRank.Application.Requests.Usuario;
using devRank.Application.Responses.Usuario;
using devRank.Domain.Contracts.Repositories;
using devRank.Shared.Extensions;
using FastResults.Results;
using Mapster;
using MediatR;

namespace devRank.Application.UseCases.UsuarioUseCase;

public class ObterUsuarioPorIdUseCase(
    ISender sender,
    IUsuarioRepository usuarioRepository) : 
    BaseUseCase<
        ObterUsuarioPorIdRequest,
        UsuarioResponse>(sender)
{
    public override async Task<BaseResult<UsuarioResponse>> Handle(
        ObterUsuarioPorIdRequest request, 
        CancellationToken cancellationToken)
    {
        var usuario = await usuarioRepository.ObterPorIdComDependencias(request.Id, cancellationToken);
        if (usuario is null)
        {
            return BaseResultExtension<UsuarioResponse>.NenhumRegistro;
        }

        return usuario.Adapt<UsuarioResponse>();
    }
}
using devRank.Application.Abstractions;
using devRank.Application.Requests.Usuario;
using devRank.Application.Responses.Usuario;
using devRank.Domain.Contracts.Repositories;
using devRank.Shared.Extensions;
using FastResults.Results;
using Mapster;
using MediatR;

namespace devRank.Application.UseCases.UsuarioUseCase;

public class ObterUsuarioPorEmailUseCase(
    ISender sender,
    IUsuarioRepository usuarioRepository) :
    BaseUseCase<
        ObterUsuarioPorEmailRequest,
        UsuarioResponse>(sender)
{
    public override async Task<BaseResult<UsuarioResponse>> Handle(
        ObterUsuarioPorEmailRequest request,
        CancellationToken cancellationToken)
    {
        var usuario = await usuarioRepository.ObterPorEmail(request.Email, cancellationToken);
        if (usuario is null)
        {
            return BaseResultExtension<UsuarioResponse>.NenhumRegistro;
        }

        return usuario.Adapt<UsuarioResponse>();
    }
}
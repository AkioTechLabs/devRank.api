using devRank.Application.Abstractions;
using devRank.Application.Requests.Usuario;
using devRank.Application.Responses.Usuario;
using devRank.Domain.Contracts.Repositories;
using devRank.Shared.Extensions;
using FastResults.Results;
using Mapster;
using MediatR;

namespace devRank.Application.UseCases.UsuarioUseCase;

public class ObterUsuarioPorAvaliadosUseCase(
    ISender sender,
    IUsuarioRepository usuarioRepository) :
    BaseUseCase<
        ObterUsuarioPorAvaliadosRequest,
        List<UsuarioResponse>>(sender)
{
    public override async Task<BaseResult<List<UsuarioResponse>>> Handle(
        ObterUsuarioPorAvaliadosRequest request,
        CancellationToken cancellationToken)
    {
        var usuarios = await usuarioRepository.ObterUsuarioAvaliados(cancellationToken);
        if (!usuarios.Any())
        {
            return BaseResultExtension<List<UsuarioResponse>>.NenhumRegistro;
        }

        return usuarios.Adapt<List<UsuarioResponse>>();
    }
}
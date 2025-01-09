using devRank.Application.Abstractions;
using devRank.Application.Requests.Perfil;
using devRank.Application.Requests.Usuario;
using devRank.Application.Responses.Usuario;
using devRank.Domain.Contracts.Repositories;
using devRank.Shared.Extensions;
using FastResults.Results;
using Mapster;
using MediatR;

namespace devRank.Application.UseCases.UsuarioUseCase;

public class AtualizarUsuarioUseCase(
    ISender sender,
    IUsuarioRepository usuarioRepository,
    IUnitOfWork unitOfWork) :
    BaseUseCase<
        AtualizarUsuarioRequest,
        UsuarioResponse>(sender)
{
    public override async Task<BaseResult<UsuarioResponse>> Handle(
        AtualizarUsuarioRequest request,
        CancellationToken cancellationToken)
    {
        var usuario = await usuarioRepository.ObterPorId(request.Id, cancellationToken);
        if (usuario is null)
        {
            return BaseResultExtension<UsuarioResponse>.NenhumRegistro;
        }

        var perfil = await sender.Send(new ObterPerfilPorIdRequest(request.PerfilId), cancellationToken);
        if (perfil.IsFailure)
        {
            return BaseResult.Failure<UsuarioResponse>(perfil.Error);
        }

        usuario.Atualizar(request.Nome, request.Ativo, request.PerfilId);

        usuarioRepository.Atualizar(usuario);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return usuario.Adapt<UsuarioResponse>();
    }
}
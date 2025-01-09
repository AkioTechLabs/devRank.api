using devRank.Application.Abstractions;
using devRank.Application.Requests.Perfil;
using devRank.Application.Requests.Usuario;
using devRank.Application.Responses.Auth;
using devRank.Domain.Contracts.Infraestructures;
using devRank.Domain.Contracts.Repositories;
using devRank.Domain.Entities;
using devRank.Shared.Messages;
using FastResults.Results;
using Mapster;
using MediatR;

namespace devRank.Application.UseCases.UsuarioUseCase;

public class CriarUsuarioUseCase(
    ISender sender,
    IUsuarioRepository usuarioRepository,
    IAuthInfra authInfra,
    IUnitOfWork unitOfWork) :
    BaseUseCase<
        CriarUsuarioRequest,
        LoginResponse>(sender)
{
    public override async Task<BaseResult<LoginResponse>> Handle(
        CriarUsuarioRequest request,
        CancellationToken cancellationToken)
    {
        var validacao = await Validar(request, cancellationToken);
        if (validacao.IsFailure)
        {
            return BaseResult.Failure<LoginResponse>(validacao.Error);
        }

        var usuario = request.Adapt<Usuario>();
        usuario.CriptografarSenha();

        usuarioRepository.Inserir(usuario);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        var token = authInfra.GerarToken(usuario);

        return new LoginResponse(
            usuario.Id,
            token.Token,
            token.DataExpiracao,
            token.RefreshToken);
    }

    private async Task<BaseResult> Validar(
        CriarUsuarioRequest request,
        CancellationToken cancellationToken)
    {
        var perfil = await sender.Send(new ObterPerfilPorIdRequest(request.PerfilId), cancellationToken);
        if (perfil.IsFailure)
        {
            return perfil;
        }

        var usuario = await sender.Send(new ObterUsuarioPorEmailRequest(request.Email), cancellationToken);
        if (usuario.IsSuccess)
        {
            return BaseResult.Failure(DevRankMessage.Usuario.EmailJaCadastrado);
        }

        return BaseResult.Sucess();
    }
}
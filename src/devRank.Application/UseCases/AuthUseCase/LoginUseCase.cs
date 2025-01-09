using devRank.Application.Abstractions;
using devRank.Application.Requests.Auth;
using devRank.Application.Requests.Usuario;
using devRank.Application.Responses.Auth;
using devRank.Domain.Contracts.Infraestructures;
using devRank.Domain.Contracts.Repositories;
using devRank.Shared.Messages;
using FastResults.Results;
using MediatR;

namespace devRank.Application.UseCases.AuthUseCase;

public class LoginUseCase(
    ISender sender,
    IAuthInfra authInfra,
    IUsuarioRepository usuarioRepository) :
    BaseUseCase<
        LoginRequest,
        LoginResponse>(sender)
{
    public override async Task<BaseResult<LoginResponse>> Handle(
        LoginRequest request,
        CancellationToken cancellationToken)
    {
        var email = await sender.Send(new ObterUsuarioPorEmailRequest(request.Email), cancellationToken);
        if (email.IsFailure)
        {
            return BaseResult.Failure<LoginResponse>(email.Error);
        }

        var usuario = await usuarioRepository.ObterPorId(email.Value.Id, cancellationToken);
        if (!usuario!.ValidarSenha(request.Senha))
        {
            return BaseResult.Failure<LoginResponse>(DevRankMessage.Auth.SenhaInvalida);
        }

        var token = authInfra.GerarToken(usuario);

        return new LoginResponse(
            usuario.Id,
            token.Token,
            token.DataExpiracao,
            token.RefreshToken);
    }
}
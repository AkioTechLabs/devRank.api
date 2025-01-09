using devRank.Application.Abstractions;
using devRank.Application.Requests.Auth;
using devRank.Application.Requests.Usuario;
using devRank.Application.Responses.Auth;
using devRank.Domain.Contracts.Infraestructures;
using devRank.Domain.Entities;
using FastResults.Results;
using Mapster;
using MediatR;

namespace devRank.Application.UseCases.AuthUseCase;

public class RefreshTokenUseCase(
    ISender sender,
    IAuthInfra authInfra) :
    BaseUseCase<
        RefreshTokenRequest,
        LoginResponse>(sender)
{
    public override async Task<BaseResult<LoginResponse>> Handle(
        RefreshTokenRequest request,
        CancellationToken cancellationToken)
    {
        var usuario = await sender.Send(new ObterUsuarioPorIdRequest(request.UsuarioId), cancellationToken);
        if (usuario.IsFailure)
        {
            return BaseResult.Failure<LoginResponse>(usuario.Error);
        }

        var usuarioRetornado = usuario.Value;
        var token = authInfra.GerarToken(usuarioRetornado.Adapt<Usuario>());

        return new LoginResponse(
            usuarioRetornado.Id,
            token.Token,
            token.DataExpiracao,
            token.RefreshToken);
    }
}
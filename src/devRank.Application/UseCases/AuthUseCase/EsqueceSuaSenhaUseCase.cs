using devRank.Application.Abstractions;
using devRank.Application.Requests.Auth;
using devRank.Application.Responses.Auth;
using devRank.Domain.Contracts.Infraestructures;
using devRank.Domain.Contracts.Repositories;
using devRank.Shared.Extensions;
using FastResults.Results;
using MediatR;

namespace devRank.Application.UseCases.AuthUseCase;

public class EsqueceSuaSenhaUseCase(
    ISender sender,
    IAuthInfra authInfra,
    IUsuarioRepository usuarioRepository,
    IUnitOfWork unitOfWork) :
    BaseUseCase<
        EsqueceSuaSenhaRequest,
        LoginResponse>(sender)
{
    public override async Task<BaseResult<LoginResponse>> Handle(
        EsqueceSuaSenhaRequest request,
        CancellationToken cancellationToken)
    {
        var usuario = await usuarioRepository.ObterPorId(request.Id, cancellationToken);
        if (usuario is null)
        {
            return BaseResultExtension<LoginResponse>.NenhumRegistro;
        }

        usuario.TrocarSenha(request.Senha);
        usuarioRepository.Atualizar(usuario);

        await unitOfWork.SaveChangesAsync(cancellationToken);
        var token = authInfra.GerarToken(usuario);

        return new LoginResponse(
            usuario.Id,
            token.Token,
            token.DataExpiracao,
            token.RefreshToken);
    }
}
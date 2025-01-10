using System.Net;
using devRank.Application.Requests.Auth;
using devRank.Application.Responses.Auth;
using devRank.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace devRank.Presentation.Controllers.v1;

[Route("v1/[controller]")]
public class AuthController(ISender sender) : ApiController(sender)
{
    /// <summary>
    /// Rota para fazer login.
    /// </summary>
    /// <param name="request">Dados para login.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação.</param>
    /// <returns>Retorna as informações de login.</returns>
    [HttpPost("login")]
    [ProducesResponseType(typeof(LoginResponse), statusCode: StatusCodes.Status201Created)]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResponse>> Login(
        [FromBody] LoginRequest request,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);
        return Response(result, HttpStatusCode.Created);
    }

    /// <summary>
    /// Rota para utilizar o refresh token.
    /// </summary>
    /// <param name="request">Dados do refresh token.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação.</param>
    /// <returns>Retorna as informações de login.</returns>
    [HttpPost("refresh-token")]
    [ProducesResponseType(typeof(LoginResponse), statusCode: StatusCodes.Status201Created)]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResponse>> Login(
        [FromBody] RefreshTokenRequest request,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);
        return Response(result, HttpStatusCode.Created);
    }

    /// <summary>
    /// Rota para quem esqueceu sua senha.
    /// </summary>
    /// <param name="request">Dados do esqueceu sua senha.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação.</param>
    /// <returns>Retorna as informações de login.</returns>
    [HttpPost("esqueceu-senha")]
    [ProducesResponseType(typeof(LoginResponse), statusCode: StatusCodes.Status201Created)]
    [AllowAnonymous]
    public async Task<ActionResult<LoginResponse>> EsqueceuSenha(
        [FromBody] EsqueceSuaSenhaRequest request,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);
        return Response(result, HttpStatusCode.Created);
    }
}
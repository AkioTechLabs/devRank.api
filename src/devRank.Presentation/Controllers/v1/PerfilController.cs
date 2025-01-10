using System.Net;
using devRank.Application.Requests.Perfil;
using devRank.Application.Responses.Perfil;
using devRank.Presentation.Abstractions;
using devRank.Presentation.Filters.Auth;
using devRank.Shared.Enums.Permissao;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace devRank.Presentation.Controllers.v1;

[Route("v1/[controller]")]
public class PerfilController(ISender sender) : ApiController(sender)
{
    /// <summary>
    /// Rota para criar um perfil.
    /// </summary>
    /// <param name="request">Dados para criação do usuario.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação.</param>
    /// <returns>Retorna as informações de login.</returns>
    /// <remarks>
    /// Requer a permissão: <b>CriarPerfil</b>
    /// </remarks>
    [HttpPost("criar")]
    [ProducesResponseType(typeof(PerfilResponse), statusCode: StatusCodes.Status201Created)]
    [Permissao(NivelPermissao.CriarPerfil)]
    public async Task<ActionResult<PerfilResponse>> Criar(
        [FromBody] CriarPerfilRequest request,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);
        return Response(result, HttpStatusCode.Created);
    }
    
    /// <summary>
    /// Rota para obter um perfil por id.
    /// </summary>
    /// <param name="request">Dados para obter o perfil.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação.</param>
    /// <returns>Retorna as informações do perfil.</returns>
    /// <remarks>
    /// Requer a permissão: <b>ObterPerfil</b>
    /// </remarks>
    [HttpGet("id")]
    [ProducesResponseType(typeof(PerfilResponse), statusCode: StatusCodes.Status200OK)]
    [Permissao(NivelPermissao.ObterPerfil)]
    public async Task<ActionResult<PerfilResponse>> ObterPorId(
        [FromQuery] ObterPerfilPorIdRequest request,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);
        return Response(result);
    }
}
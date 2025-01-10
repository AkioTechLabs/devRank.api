using System.Net;
using devRank.Application.Requests.UsuarioPonto;
using devRank.Application.Responses.UsuarioPonto;
using devRank.Presentation.Abstractions;
using devRank.Presentation.Filters.Auth;
using devRank.Shared.Enums.Permissao;
using devRank.Shared.Messages;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace devRank.Presentation.Controllers.v1;

[Route("v1/[controller]")]
public class UsuarioPontoController(ISender sender) : ApiController(sender)
{
    /// <summary>
    /// Rota para criar um usuario.
    /// </summary>
    /// <param name="request">Dados para criação do usuario.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação.</param>
    /// <returns>Retorna as informações de login.</returns>
    /// <remarks>
    /// Requer a permissão: <b>CriarPontuacao</b>
    /// </remarks>
    [HttpPost("criar")]
    [ProducesResponseType(typeof(string), statusCode: StatusCodes.Status201Created)]
    [Permissao(NivelPermissao.CriarPontuacao)]
    public async Task<ActionResult<string>> Criar(
        [FromBody] CriarUsuarioPontoRequest request,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);
        return Response(
            result,
            DevRankMessage.Comum.RegistroCadastroComSucesso,
            HttpStatusCode.Created);
    }

    /// <summary>
    /// Rota para obter os pontos.
    /// </summary>
    /// <param name="request">Dados para obter os pontos.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação.</param>
    /// <returns>Retorna as informações pelas datas.</returns>
    /// <remarks>
    /// Requer a permissão: <b>ObterPontuacao</b>
    /// </remarks>
    [HttpGet("data")]
    [ProducesResponseType(typeof(List<UsuarioPontoResponse>), statusCode: StatusCodes.Status200OK)]
    [Permissao(NivelPermissao.ObterPontuacao)]
    public async Task<ActionResult<List<UsuarioPontoResponse>>> ObterPorData(
        [FromQuery] ObterUsuarioPontoRequest request,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);
        return Response(result);
    }

    /// <summary>
    /// Rota para obter ponto por Usuario.
    /// </summary>
    /// <param name="request">Dados para obter os pontos.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação.</param>
    /// <returns>Retorna as informações pelas datas.</returns>
    /// <remarks>
    /// Requer a permissão: <b>ObterPontuacao</b>
    /// </remarks>
    [HttpGet("usuario")]
    [ProducesResponseType(typeof(UsuarioPontoCompletoResponse), statusCode: StatusCodes.Status200OK)]
    [Permissao(NivelPermissao.ObterPontuacao)]
    public async Task<ActionResult<UsuarioPontoCompletoResponse>> ObterPorUsuario(
        [FromQuery] ObterUsuarioPontoPorUsuarioRequest request,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);
        return Response(result);
    }
}
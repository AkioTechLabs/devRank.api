using System.Net;
using devRank.Application.Requests.Usuario;
using devRank.Application.Responses.Auth;
using devRank.Application.Responses.Usuario;
using devRank.Presentation.Abstractions;
using devRank.Presentation.Filters.Auth;
using devRank.Shared.Enums.Permissao;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace devRank.Presentation.Controllers.v1;

[Route("v1/[controller]")]
public class UsuarioController(ISender sender) : ApiController(sender)
{
    /// <summary>
    /// Rota para criar um usuario.
    /// </summary>
    /// <param name="request">Dados para criação do usuario.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação.</param>
    /// <returns>Retorna as informações de login.</returns>
    /// <remarks>
    /// Requer a permissão: <b>CriarUsuario</b>
    /// </remarks>
    [HttpPost("criar")]
    [ProducesResponseType(typeof(LoginResponse), statusCode: StatusCodes.Status201Created)]
    [Permissao(NivelPermissao.CriarUsuario)]
    public async Task<ActionResult<LoginResponse>> Criar(
        [FromBody] CriarUsuarioRequest request,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);
        return Response(result, HttpStatusCode.Created);
    }

    /// <summary>
    /// Rota para obter o usuario pelo Id.
    /// </summary>
    /// <param name="request">Dados para obter o usuario.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação.</param>
    /// <returns>Retorna as informações completas do usuario.</returns>
    /// <remarks>
    /// Requer a permissão: <b>ObterUsuario</b>
    /// </remarks>
    [HttpGet("id")]
    [ProducesResponseType(typeof(UsuarioResponse), statusCode: StatusCodes.Status200OK)]
    [Permissao(NivelPermissao.ObterUsuario)]
    public async Task<ActionResult<UsuarioResponse>> ObterPorId(
        [FromQuery] ObterUsuarioPorIdRequest request,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);
        return Response(result);
    }

    /// <summary>
    /// Rota para obter o usuario pelo email.
    /// </summary>
    /// <param name="request">Dados para obter o usuario.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação.</param>
    /// <returns>Retorna as informações resumidas do usuario.</returns>
    /// <remarks>
    /// Requer a permissão: <b>ObterUsuario</b>
    /// </remarks>
    [HttpGet("email")]
    [ProducesResponseType(typeof(UsuarioResponse), statusCode: StatusCodes.Status200OK)]
    [Permissao(NivelPermissao.ObterUsuario)]
    public async Task<ActionResult<UsuarioResponse>> ObterPorEmail(
        [FromQuery] ObterUsuarioPorEmailRequest request,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);
        return Response(result);
    }

    /// <summary>
    /// Rota para atualizar o usuario.
    /// </summary>
    /// <param name="request">Dados para atualizar o usuario.</param>
    /// <param name="cancellationToken">Token para cancelamento da operação.</param>
    /// <returns>Retorna as informações resumidas do usuario.</returns>
    /// <remarks>
    /// Requer a permissão: <b>AlterarUsuario</b>
    /// </remarks>
    [HttpPut("atualizar")]
    [ProducesResponseType(typeof(UsuarioResponse), statusCode: StatusCodes.Status200OK)]
    [Permissao(NivelPermissao.AlterarUsuario)]
    public async Task<ActionResult<UsuarioResponse>> Atualizar(
        [FromBody] AtualizarUsuarioRequest request,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(request, cancellationToken);
        return Response(result);
    }

    /// <summary>
    /// Rota para obter usuarios avaliados.
    /// </summary>
    /// <param name="cancellationToken">Token para cancelamento da operação.</param>
    /// <returns>Retorna as informações resumidas dos usuarios.</returns>
    /// <remarks>
    /// Requer a permissão: <b>ObterUsuario</b>
    /// </remarks>
    [HttpGet("avaliados")]
    [ProducesResponseType(typeof(List<UsuarioResponse>), statusCode: StatusCodes.Status200OK)]
    [Permissao(NivelPermissao.ObterUsuario)]
    public async Task<ActionResult<List<UsuarioResponse>>> ObterPorAvaliados(
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(new ObterUsuarioPorAvaliadosRequest(), cancellationToken);
        return Response(result);
    }
}
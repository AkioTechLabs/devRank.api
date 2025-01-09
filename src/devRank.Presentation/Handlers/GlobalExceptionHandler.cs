using System.Net;
using devRank.Shared.Errors;
using devRank.Shared.Expections;
using FastResults.Errors;
using FastResults.Results;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;

namespace devRank.Presentation.Handlers;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Erro: {Mensagem}", exception.Message);

        switch (exception)
        {
            case UnauthorizedAccessException:
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await httpContext.Response.WriteAsJsonAsync(new BaseResponse<Error>(DevRankError.Comum.AcessoNegado),
                    cancellationToken);
                break;
            case ValidacaoExpection:
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await httpContext.Response.WriteAsJsonAsync(
                    new BaseResponse<Error>(DevRankError.Comum.Validacao(exception.ToString())), cancellationToken);
                break;
            default:
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await httpContext.Response.WriteAsJsonAsync(new BaseResponse<Error>(DevRankError.Comum.ErroInterno),
                    cancellationToken);
                break;
        }

        return true;
    }
}
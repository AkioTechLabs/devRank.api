using devRank.Shared.Errors;
using devRank.Shared.Expections;
using FastResults.Errors;
using FastResults.Results;
using FluentValidation;
using MediatR;

namespace devRank.Application.Behaviors;

public class ValidationPipelineBehavior<TRequest, TResponse>(
    IEnumerable<IValidator<TRequest>> fluentValidators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : BaseResult
{
    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var erros = fluentValidators
            .Select(validator => validator.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(error => error is not null)
            .Select(error => DevRankError.Comum.Validacao(error.ErrorMessage))
            .Distinct()
            .ToList();

        if (erros.Count != 0)
        {
            throw new ValidacaoExpection(erros);
        }

        return await next();
    }
}
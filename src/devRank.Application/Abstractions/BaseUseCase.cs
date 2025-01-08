using devRank.Application.Abstractions.Contracts;
using FastResults.Results;
using MediatR;

namespace devRank.Application.Abstractions;

public abstract class BaseUseCase<TRequest>(ISender sender) : IBaseUseCase<TRequest>
    where TRequest : IRequestUseCase
{
    public abstract Task<BaseResult> Handle(TRequest request, CancellationToken cancellationToken);
}

public abstract class BaseUseCase<TRequest, TResponse>(ISender sender) : IBaseUseCase<TRequest, TResponse>
    where TRequest : IRequestUseCase<TResponse>
{
    public abstract Task<BaseResult<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);
}
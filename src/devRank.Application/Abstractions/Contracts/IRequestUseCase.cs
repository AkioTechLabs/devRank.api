using FastResults.Results;
using MediatR;

namespace devRank.Application.Abstractions.Contracts;

public interface IRequestUseCase : IRequest<BaseResult>
{
}

public interface IRequestUseCase<TResponse> : IRequest<BaseResult<TResponse>>
{
}
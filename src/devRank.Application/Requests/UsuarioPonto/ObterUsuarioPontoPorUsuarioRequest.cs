using devRank.Application.Abstractions.Contracts;
using devRank.Application.Responses.UsuarioPonto;
using MediatR;

namespace devRank.Application.Requests.UsuarioPonto;

public record ObterUsuarioPontoPorUsuarioRequest(
    long Id,
    DateTime DataInicial,
    DateTime DataFinal) : IRequestUseCase<UsuarioPontoCompletoResponse>;
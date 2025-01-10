using devRank.Application.Abstractions.Contracts;
using devRank.Application.Responses.UsuarioPonto;

namespace devRank.Application.Requests.UsuarioPonto;

public record ObterUsuarioPontoRequest(
    DateTime DataInicial,
    DateTime DataFinal) : IRequestUseCase<List<UsuarioPontoResponse>>;
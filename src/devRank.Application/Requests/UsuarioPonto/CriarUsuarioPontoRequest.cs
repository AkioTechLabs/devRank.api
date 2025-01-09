using devRank.Application.Abstractions.Contracts;
using devRank.Shared.Enums.Usuario;

namespace devRank.Application.Requests.UsuarioPonto;

public record CriarUsuarioPontoRequest(
    long UsuarioId,
    string Observacao,
    int Ponto,
    TipoPonto Tipo) : IRequestUseCase;
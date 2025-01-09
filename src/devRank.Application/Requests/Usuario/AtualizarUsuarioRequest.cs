using devRank.Application.Abstractions.Contracts;
using devRank.Application.Responses.Usuario;

namespace devRank.Application.Requests.Usuario;

public record AtualizarUsuarioRequest(
    long Id,
    string Nome,
    bool Ativo,
    int PerfilId) : IRequestUseCase<UsuarioResponse>;
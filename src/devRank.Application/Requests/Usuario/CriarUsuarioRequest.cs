using devRank.Application.Abstractions.Contracts;
using devRank.Application.Responses.Auth;
using devRank.Application.Responses.Usuario;

namespace devRank.Application.Requests.Usuario;

public record CriarUsuarioRequest(
    string Nome,
    string Email,
    string Senha,
    long PerfilId) : IRequestUseCase<LoginResponse>;
using devRank.Application.Abstractions.Contracts;
using devRank.Application.Responses.Auth;

namespace devRank.Application.Requests.Auth;

public record RefreshTokenRequest(
    long UsuarioId,
    string RefreshToken) : IRequestUseCase<LoginResponse>;
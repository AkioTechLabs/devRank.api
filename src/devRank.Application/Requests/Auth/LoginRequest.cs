using devRank.Application.Abstractions.Contracts;
using devRank.Application.Responses.Auth;

namespace devRank.Application.Requests.Auth;

public record LoginRequest(
    string Email,
    string Senha) : IRequestUseCase<LoginResponse>;
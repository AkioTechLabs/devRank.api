namespace devRank.Application.Responses.Auth;

public record LoginResponse(
    long UsuarioId,
    string Token,
    DateTime DataExpiracao,
    Guid RefreshToken);
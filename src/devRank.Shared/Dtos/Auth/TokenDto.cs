namespace devRank.Shared.Dtos.Auth;

public record TokenDto(
    string Token,
    DateTime DataExpiracao,
    Guid RefreshToken);
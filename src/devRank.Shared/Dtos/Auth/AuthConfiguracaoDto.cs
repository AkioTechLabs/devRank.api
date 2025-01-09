namespace devRank.Shared.Dtos.Auth;

public class AuthConfiguracaoDto
{
    public string Key { get; init; } = string.Empty;
    public string KeyIssuer  { get; init; } = string.Empty;
    public string KeyAudience  { get; init; } = string.Empty;
    public int DiasParaExpiracao { get; init; }
}
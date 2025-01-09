namespace devRank.Application.Responses.Usuario;

public record UsuarioResponse(
    long Id,
    string Nome,
    string Email,
    bool Avaliado,
    bool Ativo,
    long PerfilId);
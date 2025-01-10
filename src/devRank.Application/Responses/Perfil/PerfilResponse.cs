namespace devRank.Application.Responses.Perfil;

public record PerfilResponse(
    int Id,
    string Descricao,
    List<PerfilPermissaoResponse> Permissoes);
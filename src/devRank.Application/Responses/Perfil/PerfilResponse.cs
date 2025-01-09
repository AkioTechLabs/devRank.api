namespace devRank.Application.Requests.Perfil;

public record PerfilResponse(
    int PerfilId,
    string PerfilDescricao,
    List<PerfilPermissaoResponse> Permissoes);
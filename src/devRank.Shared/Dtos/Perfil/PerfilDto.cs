namespace devRank.Shared.Dtos.Perfil;

public record PerfilDto(
    long PerfilId,
    string PerfilDescricao,
    List<PerfilPermissaoDto> Permissoes);
    
public record PerfilPermissaoDto(
    long PermissaoId,
    string PermissaoDescricao);
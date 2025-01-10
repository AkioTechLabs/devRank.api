using devRank.Shared.Enums.Permissao;
using Microsoft.AspNetCore.Authorization;

namespace devRank.Presentation.Filters.Auth;

public class PermissaoAttribute(NivelPermissao permissoes) : AuthorizeAttribute(policy: permissoes.ToString());
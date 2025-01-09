using devRank.Application.Abstractions.Contracts;
using devRank.Application.Responses.Usuario;

namespace devRank.Application.Requests.Usuario;

public record ObterUsuarioPorEmailRequest(string Email) : IRequestUseCase<UsuarioResponse>;
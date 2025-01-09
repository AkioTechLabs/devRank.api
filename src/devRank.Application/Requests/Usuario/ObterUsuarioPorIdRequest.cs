using devRank.Application.Abstractions.Contracts;
using devRank.Application.Responses.Usuario;

namespace devRank.Application.Requests.Usuario;

public record ObterUsuarioPorIdRequest(long Id) : IRequestUseCase<UsuarioResponse>;
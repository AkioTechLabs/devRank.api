using devRank.Domain.Abstractions.Contracts;
using devRank.Domain.Entities;
using devRank.Shared.Dtos.Auth;

namespace devRank.Domain.Contracts.Infraestructures;

public interface IAuthInfra : IRepository
{
    TokenDto GerarToken(Usuario usuario);
}
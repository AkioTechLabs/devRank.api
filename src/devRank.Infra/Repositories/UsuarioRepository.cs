using devRank.Domain.Contracts.Repositories;
using devRank.Domain.Entities;
using devRank.Infra.Abstractions;
using devRank.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace devRank.Infra.Repositories;

public class UsuarioRepository(DevRankContext context) :
    BaseRepository<Usuario>(context),
    IUsuarioRepository
{
    public async Task<Usuario?> ObterPorEmail(
        string email,
        CancellationToken cancellationToken)
    {
        return await context.Usuario
            .AsNoTracking()
            .Include(u => u.Perfil)
            .FirstOrDefaultAsync(u => u.Email == email && u.Ativo, cancellationToken);
    }

    public async Task<Usuario?> ObterPorIdComDependencias(
        long id,
        CancellationToken cancellationToken)
    {
        return await context.Usuario
            .AsNoTracking()
            .Include(u => u.Perfil)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    public async Task<List<Usuario>> ObterUsuarioAvaliados(CancellationToken cancellationToken)
    {
        return await context.Usuario
            .AsNoTracking()
            .Where(u => u.Ativo && u.Avaliado)
            .ToListAsync(cancellationToken);
    }
}
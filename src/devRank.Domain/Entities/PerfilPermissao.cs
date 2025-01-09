using devRank.Domain.Abstractions;

namespace devRank.Domain.Entities;

public sealed class PerfilPermissao() : AuditEntity
{
    #region Properties

    public long PerfilId { get; private set; }
    public long PermissaoId { get; private set; }

    #region Ref. Foreign Key

    public Perfil? Perfil { get; set; }
    public Permissao? Permissao { get; set; }

    #endregion Ref. Foreign Key

    #endregion Properties

    #region Constructors

    public PerfilPermissao(
        long idPerfil, 
        long idPermissao) : this()
    {
        PerfilId = idPerfil;
        PermissaoId = idPermissao;
    }

    #endregion Constructors

    #region Methods

    protected override void Validar()
    {
    }

    #endregion Methods
}
using devRank.Domain.Abstractions;
using devRank.Domain.Validators.Usuario;
using SecureIdentity.Password;

namespace devRank.Domain.Entities;

public sealed class Usuario() : AuditEntity
{
    #region Properties

    public string Nome { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Senha { get; private set; } = string.Empty;
    public long PerfilId { get; private set; }
    public bool Ativo { get; private set; } = true;
    
    #region Prop. Aux

    public Perfil Perfil { get; private set; }

    #endregion Prop. Aux

    #endregion Properties

    #region Constructors

    public Usuario(
        string nome,
        string email,
        string senha,
        int perfilId) : this()
    {
        Nome = nome;
        Email = email;
        Senha = senha;
        PerfilId = perfilId;
        Ativo = true;

        CriptografarSenha();
        Validar();
    }

    #endregion Constructors

    #region Methods

    public void CriptografarSenha()
    {
        string senha = PasswordHasher.Hash(Senha);
        Senha = senha;
    }

    public bool ValidarSenha(string senha)
    {
        return PasswordHasher.Verify(Senha, senha);
    }

    public void TrocarSenha(string senha)
    {
        Senha = senha;
        CriptografarSenha();
    }

    public void Atualizar(
        string nome,
        bool ativo,
        int perfilId)
    {
        Nome = nome;
        Ativo = ativo;
        PerfilId = perfilId;

        Validar();
    }

    protected override void Validar()
    {
        UsuarioValidator validar = new();
        ValidarInternal(validar, this);
    }

    #endregion Methods
}
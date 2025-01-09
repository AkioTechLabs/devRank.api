using devRank.Domain.Abstractions;
using devRank.Domain.Validators.Usuario;
using devRank.Shared.Enums.Usuario;

namespace devRank.Domain.Entities;

public sealed class UsuarioPonto() : AuditEntity
{
    #region Properties

    public int Ponto { get; private set; }
    public TipoMovimento Movimento { get; private set; }
    public TipoPonto Tipo { get; private set; }
    public string Observacao { get; private set; } = string.Empty;
    public long UsuarioId { get; private set; }
    public bool Ativo { get; private set; } = true;

    #region Prop. Aux

    public Usuario Usuario { get; private set; }

    #endregion Prop. Aux

    #endregion Properties

    #region Constructors

    public UsuarioPonto(
        int ponto,
        TipoPonto tipo,
        string observacao,
        long usuarioId) : this()
    {
        Tipo = tipo;
        Observacao = observacao;
        UsuarioId = usuarioId;
        Ativo = true;

        AtribuirPonto(ponto);
        Validar();
    }

    #endregion Constructors

    #region Methods

    public void AtribuirPonto(int ponto)
    {
        switch (Tipo)
        {
            case TipoPonto.AprovadoPullRequest:
            case TipoPonto.AprovadoTeste:
            case TipoPonto.Documentacao:
                Ponto = 1;
                Movimento = TipoMovimento.Ganhar;
                break;

            case TipoPonto.ReprovadoPullRequest:
            case TipoPonto.ReprovadoTeste:
            case TipoPonto.PrDemoradoOuAtrasoTask:
                Ponto = 1;
                Movimento = TipoMovimento.Perder;
                break;

            case TipoPonto.ForaDoPadrao:
                Ponto = ponto;
                Movimento = TipoMovimento.Perder;
                break;

            case TipoPonto.Colaboracao:
                Ponto = 2;
                Movimento = TipoMovimento.Ganhar;
                break;

            case TipoPonto.FastCodes:
                Ponto = 5;
                Movimento = TipoMovimento.Ganhar;
                break;

            case TipoPonto.FaltaComunicao:
                Ponto = 2;
                Movimento = TipoMovimento.Perder;
                break;

            case TipoPonto.ReprovacaoRepetidads:
            case TipoPonto.Retrabalho:
                Ponto = 5;
                Movimento = TipoMovimento.Perder;
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(Tipo), $"Tipo de ponto inválido: {Tipo}");
        }

    }

    protected override void Validar()
    {
        UsuarioPontoValidator validator = new();
        ValidarInternal(validator, this);
    }

    #endregion Methods
}
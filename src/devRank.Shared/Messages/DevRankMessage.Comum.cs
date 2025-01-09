namespace devRank.Shared.Messages;

public partial class DevRankMessage
{
    public class Comum
    {
        public static string RegistroCadastroComSucesso => "Registro cadastrado com sucesso!";

        public static string RegistroAlteradoComSucesso => "Registro alterado com sucesso!";

        public static string NenhumRegistroLocalizado => "Nenhum registro foi localizado!";

        public static string NenhumRegistroLocalizadoLabel(string campo) =>
            "Nenhum registro foi localizado - " + campo + "!";

        public static string ValorInvalido(string campo) => "O " + campo + " está invalido.";

        public static string EmailInvalido => "Email invalido!";

        public static string CampoObrigatorio => "O campo {PropertyName} é obrigatorio!";

        public static string TamanhoDiferente(int limiteMinimo, int limiteMaximo) =>
            $"O tamanho mínimo é de {limiteMinimo} e máximo de {limiteMaximo} caracteres!";

        public static string NaoPossuiId(string label, long idProjeto) =>
            $"O {label} {idProjeto} não existe!";
    }
}
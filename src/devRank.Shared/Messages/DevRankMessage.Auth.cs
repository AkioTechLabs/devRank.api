namespace devRank.Shared.Messages;

public partial class DevRankMessage
{
    public class Auth
    {
        public static string Maiuscula => "A senha deve conter pelo menos uma letra maiúscula.";
        public static string Minuscula => "A senha deve conter pelo menos uma letra minúscula.";
        public static string Numero => "A senha deve conter pelo menos um número.";
        public static string CaracteresEspecial => "A senha deve conter pelo menos um caractere especial.";
        public static string EmailJaExiste => "Email já existe!";
        public static string EmailInvalido => "Email Invalido!";
        public static string SenhaInvalida => "Senha está invalida!";
    }
}
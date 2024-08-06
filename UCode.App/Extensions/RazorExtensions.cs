using System.Text.RegularExpressions;

namespace UCode.App.Extensions
{
    public static class RazorExtensions
    {
        public static string FormataCpf(this string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                throw new ArgumentException("CPF não pode ser nulo ou vazio");
            }

            // Remove todos os caracteres não numéricos
            cpf = Regex.Replace(cpf, @"\D", "");

            if (cpf.Length != 11 || !long.TryParse(cpf, out long cpfNumerico))
            {
                throw new ArgumentException("CPF inválido");
            }

            return cpfNumerico.ToString(@"000\.000\.000\-00");
        }

        public static string FormataSiape(this string siape)
        {
            if (string.IsNullOrWhiteSpace(siape))
            {
                throw new ArgumentException("Siape não pode ser nulo ou vazio");
            }

            // Remove todos os caracteres não numéricos
            siape = Regex.Replace(siape, @"\D", "");

            if (siape.Length != 9 || !long.TryParse(siape, out long siapeNumerico))
            {
                throw new ArgumentException("CPF inválido");
            }

            return siapeNumerico.ToString(@"000\.000\.000");
        }
    }
}

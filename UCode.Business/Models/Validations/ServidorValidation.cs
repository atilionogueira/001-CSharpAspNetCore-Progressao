using DevIO.Business.Model.Validations.Documentos;
using FluentValidation;

namespace UCode.Business.Models.Validations
{
    public class ServidorValidation : AbstractValidator<Servidor>
    {
        public ServidorValidation()
        {
            RuleFor(s => s.NomeCompleto)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e{MaxLength} caracteres");

            RuleFor(s => s.Siape)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Must(siape => int.TryParse(siape, out int siapeNumero) && siapeNumero > 0)
              .WithMessage("O campo {PropertyName} precisa ser um número maior que zero");

            RuleFor(s => s.Cpf.Length).Equal(CpfValidacao.TamanhoCpf)
                .WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}");            

            RuleFor(s => CpfValidacao.Validar(s.Cpf)).Equal(true)
                .WithMessage("O documento fornecido é inválido");
        }
    }
}

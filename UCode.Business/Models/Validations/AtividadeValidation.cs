using FluentValidation;

namespace UCode.Business.Models.Validations
{
    internal class AtividadeValidation : AbstractValidator<Atividade>
    {
        public AtividadeValidation()
        {
               RuleFor(s => s.Detalhes)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(2, 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
            
            RuleFor(s => s.Descricao)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(2, 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(s => s.Numero)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(a => a.Pontos)
              .GreaterThan(0).WithMessage("Pontos deve ser maior que zero.")
              .PrecisionScale(5, 2, true).WithMessage("Pontos deve ter no máximo 5 dígitos no total, com até 2 casas decimais.");
        }
    }
}

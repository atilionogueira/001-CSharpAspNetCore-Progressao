using FluentValidation;

namespace UCode.Business.Models.Validations
{
    public class ClasseValidation : AbstractValidator<Classe>
    {
        public ClasseValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("O campo {PropertyName} precisa ter entre {MInLength} e {MaxLength} caracteres");

            RuleFor(s => s.Descricao)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(2, 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(c => c.Nivel)
           .GreaterThanOrEqualTo(1)
           .WithMessage("O {PropertName} deve ser maior ou igual a 1.");

        }
    }
}

using FluentValidation;

namespace UCode.Business.Models.Validations
{
    public class CampusValidation : AbstractValidator<Campus>
    {
        public CampusValidation()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O campo {PropertName} precisa ser fornecido")
                .Length(2, 100)
                .WithMessage("o campo {PropertyName} precisa ter entre {MInLength} e {MaxLength} caracteres");

            RuleFor(c => c.Telefone)
           .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
           .Matches(@"^\(?\d{2}\)?[\s-]?\d{4,5}-?\d{4}$").WithMessage("O campo {PropertyName} está em um formato inválido");
        }
    }

}


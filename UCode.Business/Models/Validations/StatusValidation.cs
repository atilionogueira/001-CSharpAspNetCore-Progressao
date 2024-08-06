using FluentValidation;

namespace UCode.Business.Models.Validations
{
    public class StatusValidation : AbstractValidator<Status>
    {
        public StatusValidation()
        {
            RuleFor(s => s.Nome)
              .NotEmpty().WithMessage("O campo {PropertName} precisa ser fornecido")
              .Length(2, 50)
              .WithMessage("o campo {PropertyName} precisa ter entre {MInLength} e {MaxLength} caracteres");
           
            RuleFor(s => s.Descricao)
              .NotEmpty().WithMessage("O campo {PropertName} precisa ser fornecido")
              .Length(2, 150)
              .WithMessage("o campo {PropertyName} precisa ter entre {MInLength} e {MaxLength} caracteres");
        }
    }
}

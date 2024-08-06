using FluentValidation;


namespace UCode.Business.Models.Validations
{
    public class SituacaoValidation : AbstractValidator<Situacao>
    {
        public SituacaoValidation()
        {
            RuleFor(s => s.Detalhes)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(2, 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        }

    }
}

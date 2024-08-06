using FluentValidation;

namespace UCode.Business.Models.Validations
{
    public class ProgressaoValidation : AbstractValidator<Progressao>
    {
        public ProgressaoValidation()
        {
            RuleFor(p => p.ClasseId)
             .NotEmpty().WithMessage("O campo ClasseId é obrigatório.");            

            RuleFor(p => p.DataInicial)
                .NotEmpty().WithMessage("O campo DataInicial é obrigatório.")
                .LessThan(p => p.DataFinal).WithMessage("DataInicial deve ser menor que DataFinal.");

            RuleFor(p => p.DataFinal)
                .NotEmpty().WithMessage("O campo DataFinal é obrigatório.")
                .GreaterThan(p => p.DataInicial).WithMessage("DataFinal deve ser maior que DataInicial.");

            RuleFor(s => s.Observacao)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(2, 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");


        }
    }
}

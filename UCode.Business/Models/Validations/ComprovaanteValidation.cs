using FluentValidation;


namespace UCode.Business.Models.Validations
{
    internal class ComprovaanteValidation : AbstractValidator<Comprovante>
    {
        public ComprovaanteValidation()
        {
            RuleFor(c =>c.Quantidade)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(c => c.Data)
             .NotEmpty().WithMessage("O campo Data Inicial é obrigatório.");           

            RuleFor(c => c.DataFinal)
               .NotEmpty().WithMessage("O campo Data Final é obrigatório.")
               .LessThan(p => p.DataFinal).WithMessage("Data Final deve ser menor que Data Inicial.");

            RuleFor(c => c.Arquivo)
            .NotEmpty().WithMessage("O campo Arquivo é obrigatório.");
        }
    }
}


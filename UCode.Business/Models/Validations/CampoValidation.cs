using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCode.Business.Models.Validations
{
    public class CampoValidation : AbstractValidator<Campo>
    {
        public CampoValidation()
        {
            RuleFor(s => s.Nome)
               .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
               .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e{MaxLength} caracteres");

            RuleFor(s => s.Descricao)
              .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
              .Length(2, 150).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        }
    }
}

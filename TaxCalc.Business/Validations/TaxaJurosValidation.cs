using FluentValidation;
using TaxCalc.Business.Models;

namespace TaxCalc.Business.Validations
{
    public class TaxaJurosValidation : AbstractValidator<TaxaJuros>
    {
        public TaxaJurosValidation()
        {
            RuleFor(u => u.Valor)
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} deve ter maior ou igual a 0 (zero).");
        }
    }
}

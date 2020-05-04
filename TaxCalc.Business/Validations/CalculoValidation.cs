using FluentValidation;
using TaxCalc.Business.Models;

namespace TaxTrader.Business.Validations
{
    public class CalculoValidation : AbstractValidator<Calculo>
    {
        public CalculoValidation()
        {
            RuleFor(u => u.ValorInicial)
                .GreaterThan(0).WithMessage("O campo {PropertyName} deve ser maior do que zero.");
            RuleFor(u => u.Tempo)
                .GreaterThan(0).WithMessage("O campo {PropertyName} deve ser maior do que zero.");
        }
    }
}

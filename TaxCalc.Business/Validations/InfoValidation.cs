using FluentValidation;
using TaxCalc.Business.Models;

namespace TaxCalc.Business.Validations
{
    public class InfoValidation : AbstractValidator<Info>
    {
        public InfoValidation()
        {
            RuleFor(u => u.TaxTraderSource)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar vazio.");
            RuleFor(u => u.TaxCalcSource)
                .NotEmpty().WithMessage("O campo {PropertyName} não pode estar vazio.");
        }
    }
}

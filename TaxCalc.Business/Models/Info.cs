using System;
using System.Collections.Generic;
using System.Text;
using TaxCalc.Business.Validations;

namespace TaxCalc.Business.Models
{
    public class Info : Entidade
    {
        public string TaxTraderSource { get; set; }
        public string TaxCalcSource { get; set; }

        public override bool IsValid()
        {
            var taxaJurosValidacao = new InfoValidation();
            ValidationResult = taxaJurosValidacao.Validate(this);

            return ValidationResult.IsValid;
        }
    }
}

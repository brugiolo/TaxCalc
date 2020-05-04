using System;
using System.Collections.Generic;
using System.Text;
using TaxCalc.Business.Validations;

namespace TaxCalc.Business.Models
{
    public class TaxaJuros : Entidade
    {
        public decimal Valor { get; set; }

        public override bool IsValid()
        {
            var taxaJurosValidacao = new TaxaJurosValidation();
            ValidationResult = taxaJurosValidacao.Validate(this);

            return ValidationResult.IsValid;
        }
    }
}

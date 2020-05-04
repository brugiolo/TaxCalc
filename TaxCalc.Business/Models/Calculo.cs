using System;
using System.Collections.Generic;
using System.Text;
using TaxTrader.Business.Validations;

namespace TaxCalc.Business.Models
{
    public partial class Calculo : Entidade
    {
        public decimal ValorInicial { get; set; }
        public int Tempo { get; set; }
        public double Resultado { get; set; }

        public override bool IsValid()
        {
            var taxaJurosValidacao = new CalculoValidation();
            ValidationResult = taxaJurosValidacao.Validate(this);

            return ValidationResult.IsValid;
        }
    }
}

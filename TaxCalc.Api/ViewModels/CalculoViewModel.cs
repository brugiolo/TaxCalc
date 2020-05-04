using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaxCalc.Api.ViewModels
{
    public class CalculoViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal ValorInicial { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Tempo { get; set; }

        public decimal Resultado { get; set; }
    }
}

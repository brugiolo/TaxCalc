using System;
using System.Threading.Tasks;
using TaxCalc.Business.Interface;
using TaxCalc.Business.Models;

namespace TaxCalc.Business.Services
{
    public class CalculosService : ICalculosService
    {
        public async Task<Calculo> CalcularResultado(decimal valor, int tempoEmMeses)
        {
            throw new NotImplementedException();
        }
    }
}

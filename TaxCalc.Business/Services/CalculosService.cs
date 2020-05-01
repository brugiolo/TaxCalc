using System;
using System.Threading.Tasks;
using TaxCalc.Business.Interface;

namespace TaxCalc.Business.Services
{
    public class CalculosService : ICalculosService
    {
        public Task<decimal> CalcularJuros(decimal valor, int tempoEmMeses)
        {
            throw new NotImplementedException();
        }
    }
}

using System.Threading.Tasks;
using TaxCalc.Business.Models;

namespace TaxCalc.Business.Interface
{
    public interface ICalculosService
    {
        public Task<Calculo> CalcularResultado(decimal valor, int tempoEmMeses);
    }
}
using System.Threading.Tasks;
using TaxCalc.Business.Models;

namespace TaxCalc.Business.Interface
{
    public interface ICalculoService
    {
        public Task<Calculo> CalcularResultado(decimal valorInicial, int tempo);
    }
}
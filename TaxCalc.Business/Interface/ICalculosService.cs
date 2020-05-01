using System.Threading.Tasks;

namespace TaxCalc.Business.Interface
{
    public interface ICalculosService
    {
        public Task<decimal> CalcularJuros(decimal valor, int tempoEmMeses);
    }
}

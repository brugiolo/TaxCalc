using System.Threading.Tasks;
using TaxCalc.Business.Models;

namespace TaxCalc.Business.Interface
{
    public interface IInfoService
    {
        public Task<Info> ObterInfo();
    }
}
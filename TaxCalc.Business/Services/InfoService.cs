using System;
using System.Threading.Tasks;
using TaxCalc.Business.Interface;
using TaxCalc.Business.Models;

namespace TaxCalc.Business.Services
{
    public class InfoService : IInfoService
    {
        public async Task<Info> ObterInfo()
        {
            var info = new Info
            {
                TaxCalcSource = "https://github.com/brugiolo/TaxCalc.Api",
                TaxTraderSource = "https://github.com/brugiolo/TaxTrader.Api"
            };

            return await Task.FromResult<Info>(info);
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaxCalc.Api.ViewModels;
using TaxCalc.Business.Models;

namespace TaxCalc.Api.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Calculo, CalculoViewModel>().ReverseMap();
            CreateMap<Info, InfoViewModel>().ReverseMap();
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaxCalc.Api.ViewModels;
using TaxCalc.Business.Interface;

namespace TaxCalc.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculosController : ControllerBase
    {
        private readonly ICalculosService _calculosService;
        private readonly IMapper _mapper;

        public CalculosController(ICalculosService calculosService, IMapper mapper) : base()
        {
            _calculosService = calculosService;
            _mapper = mapper;
        }

        [HttpGet("calculajuros")]
        public async Task<ActionResult<CalculoViewModel>> CalculaJuros(decimal valorInicial, int tempo)
        {
            var calculo = await _calculosService.CalcularResultado(valorInicial, tempo);
            var calculoViewModel = _mapper.Map<CalculoViewModel>(calculo);

            return Ok(calculoViewModel);
        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TaxCalc.Api.ViewModels;
using TaxCalc.Business.Interface;

namespace TaxCalc.Api.Controllers
{
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculoService _calculosService;
        private readonly IMapper _mapper;

        public CalculaJurosController(ICalculoService calculosService, IMapper mapper) : base()
        {
            _calculosService = calculosService;
            _mapper = mapper;
        }

        [HttpGet("CalculaJuros")]
        public async Task<ActionResult<CalculoViewModel>> CalculaJuros(decimal valorInicial, int tempo)
        {
            try
            {
                var calculo = await _calculosService.CalcularResultado(valorInicial, tempo);
                var calculoViewModel = _mapper.Map<CalculoViewModel>(calculo);

                return Ok(calculoViewModel);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
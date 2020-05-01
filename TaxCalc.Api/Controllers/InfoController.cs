using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaxCalc.Api.ViewModels;
using TaxCalc.Business.Interface;

namespace TaxCalc.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfoController : ControllerBase
    {
        private readonly IInfoService _infoService;
        private readonly IMapper _mapper;

        public InfoController(IInfoService infoService, IMapper mapper) : base()
        {
            _infoService = infoService;
            _mapper = mapper;
        }

        [HttpGet("showmethecode")]
        public async Task<ActionResult<InfoViewModel>> ShowMeTheCode()
        {
            var info = await _infoService.ObterInfo();
            var infoViewModel = _mapper.Map<InfoViewModel>(info);

            return Ok(infoViewModel);
        }
    }
}
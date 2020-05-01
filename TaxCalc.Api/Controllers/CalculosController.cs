using Microsoft.AspNetCore.Mvc;

namespace TaxCalc.Api.Controllers
{
    public class CalculosController : ControllerBase
    {
        [HttpGet("calculajuros")]
        public IActionResult CalculaJuros()
        {
            return Ok();
        }
    }
}
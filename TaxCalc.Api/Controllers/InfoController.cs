using Microsoft.AspNetCore.Mvc;

namespace TaxCalc.Api.Controllers
{
    public class InfoController : ControllerBase
    {
        [HttpGet("showmethecode")]
        public IActionResult ShowMeTheCode()
        {
            return Ok();
        }
    }
}
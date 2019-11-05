using System.Collections.Generic;
using checkcoiAPI.Models;
using checkcoiAPI.Services.Implement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using static checkcoiAPI.Models.DTO;

namespace checkcoiAPI.Controllers
{
    public class CheckCoinController : Controller
    {
        private readonly CheckCoinService _CheckCoinService;

        public CheckCoinController(IConfiguration configuration)
        {
            _CheckCoinService = new CheckCoinService(configuration.GetSection("CheckCoinAPI"));
        }
        [HttpPost]
        [Route("api/checktoken")]
        public IActionResult CheckCoinWithAPI([FromBody] List<string> lstWallet, string contractTK, int contractDecimal)
        {
            var lstCheck = _CheckCoinService.CheckCoinInWallet(lstWallet, contractTK, contractDecimal);
            return Json(new ActionResultDto
            {
                Result = lstCheck
            });
        }
        [HttpPost]
        [Route("api/checktoken2")]
        public IActionResult CheckCoinWithAPITokenBalance([FromBody] List<string> lstWallet, string contractTK)
        {
            var lstCheck = _CheckCoinService.CheckCoinInWallet2(lstWallet, contractTK);
            return Json(new ActionResultDto
            {
                Result = lstCheck
            });
        }
    }
}
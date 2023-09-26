using HeonBankPrueba.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeonBankPrueba.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BancosController : ControllerBase
    {
        private readonly BancosService _service;

        public BancosController(BancosService service) 
        { 
            _service = service;
        }

        [HttpGet]
        public async Task<dynamic> GetBancos() 
        {
            return await _service.GetBancos();
        }

        [HttpGet]
        [Route("{bcoId}")]
        public async Task<dynamic> GetBanco(int bcoId) 
        {
            return await _service.GetBanco(bcoId);
        }
    }
}

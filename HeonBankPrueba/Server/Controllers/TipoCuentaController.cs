using HeonBankPrueba.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeonBankPrueba.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoCuentaController : ControllerBase
    {
        private readonly TipoCuentaService _service;

        public TipoCuentaController(TipoCuentaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<dynamic> GetTipoCuentas()
        {
            return await _service.GetTipoCuentas();
        }

        [HttpGet]
        [Route("{tpcId}")]
        public async Task<dynamic> GetTipoCuenta(int tpcId)
        {
            return await _service.GetTipoCuenta(tpcId);
        }
    }
}

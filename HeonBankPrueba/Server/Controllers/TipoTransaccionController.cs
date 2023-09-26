using HeonBankPrueba.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeonBankPrueba.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoTransaccionController : ControllerBase
    {
        private readonly TipoTransaccionService _service;

        public TipoTransaccionController(TipoTransaccionService service) 
        { 
            _service= service;  
        }

        [HttpGet]
        public async Task<dynamic> GetTipoTransaccion() 
        {
            return await _service.GetTipoTransaccion();
        }
    }
}

using HeonBankPrueba.Server.Services;
using HeonBankPrueba.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeonBankPrueba.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoIdentificacionController : ControllerBase
    {
        private readonly TipoIdentificacionService _service;
        public TipoIdentificacionController(TipoIdentificacionService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<dynamic> GetTipoIdentificacion()
        {
            return await _service.GetTipoIdentificacion();
        }

        
    }
}

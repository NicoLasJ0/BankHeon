using HeonBankPrueba.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeonBankPrueba.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormaPagoController : ControllerBase
    {
        private readonly FormaPagoService _service;
        public FormaPagoController(FormaPagoService service) 
        {
            _service = service;
        }

        [HttpGet]
        public async Task<dynamic> GetFormasPago() 
        { 
            return await _service.GetFormasPago();
        }
    }
}

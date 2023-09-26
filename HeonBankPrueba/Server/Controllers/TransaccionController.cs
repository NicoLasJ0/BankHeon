using HeonBankPrueba.Server.Services;
using HeonBankPrueba.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HeonBankPrueba.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransaccionController : ControllerBase
    {
        private readonly TransaccionService _transaccionService;
        public TransaccionController(TransaccionService transaccionService) 
        { 
            this._transaccionService = transaccionService;
        }  

        [HttpGet]
        public async Task<dynamic> GetTransacciones()
        {
            return await _transaccionService.GetTransacciones();
        }

        [HttpGet("{trnsId}")]
        public async Task<dynamic> GetTransaccion(int trnsId)
        {
            return await _transaccionService.GetTransaccion(trnsId);
        }

        [HttpPost]
        public async Task<dynamic> CreateTransaccion([FromBody] Transaccion transaccion)
        {
            if (transaccion.TrnsId != 0) 
            {
                return BadRequest(new {Message= "Inserte los campos correctamente"});
            }

            return await _transaccionService.SaveTransaccion(transaccion);
        }

        [HttpPut]
        public async Task<dynamic> UpdateTransaccion([FromBody] Transaccion transaccion)
        {
            if (transaccion.TrnsId == 0)
            {
                return BadRequest(new { Message = "Inserte los campos correctamente" });
            }

            return await _transaccionService.SaveTransaccion(transaccion);
        }

        [HttpDelete("{trnsId}")]
        public async Task Delete(int trnsId)
        {
            await _transaccionService.DeleteTransaccion(trnsId);
        }
    }
}

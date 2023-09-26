using HeonBankPrueba.Server.Services;
using HeonBankPrueba.Shared;
using Microsoft.AspNetCore.Mvc;


namespace HeonBankPrueba.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentaBancariaController : ControllerBase
    {
        private readonly CuentaBancariaService _cuentaBancariaService;
        public CuentaBancariaController(CuentaBancariaService cuentaBancariaService) 
        {
            _cuentaBancariaService = cuentaBancariaService;
        }   
        
        [HttpGet]
        public async Task<dynamic> GetCuentasBancarias()
        {
            return await _cuentaBancariaService.GetCuentasBancarias();
        }
        
        [HttpGet("{CubId}")]
        public async Task<dynamic> GetCuentaBancaria(int CubId)
        {
            return await _cuentaBancariaService.GetCuentaBancaria(CubId);
        }
        
        [HttpPost]
        public async Task<dynamic> CreateCuentaBancaria([FromBody] CuentaBancaria cuenta)
        {
            if (cuenta.CubId != 0) 
            {
                return BadRequest(new {Message= "Por favor, inserte los campos correctamente"});
            }
            return await _cuentaBancariaService.SaveCuentaBancaria(cuenta);
        }
        
        [HttpPut]
        public async Task<dynamic> UpdateCuentaBancaria([FromBody] CuentaBancaria cuenta)
        {
            if (cuenta.CubId == 0) 
            {
                return BadRequest(new {Message= "Por favor, inserte los campos correctamente"});
            }

            return await _cuentaBancariaService.SaveCuentaBancaria(cuenta);
        }

        [HttpDelete("{CubId}")]
        public async Task DeleteCuentaBancaria(int CubId)
        {
            await _cuentaBancariaService.DeleteCuentaBancaria(CubId);
        }
    }
}

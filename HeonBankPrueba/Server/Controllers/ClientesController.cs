using HeonBankPrueba.Server.Services;
using HeonBankPrueba.Shared;
using Microsoft.AspNetCore.Mvc;

namespace HeonBankPrueba.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClientesService _clientesService;
        public ClientesController(ClientesService clientesService)
        {
            this._clientesService = clientesService;
        }
        [HttpGet]
        public async Task<List<dynamic>> GetClientes()
        {
            return await _clientesService.GetClientes(null);
        }

        [HttpGet]
        [Route("{cliId}")]
        public async Task<dynamic> GetCliente(int cliId)
        {
            return await _clientesService.GetCliente(cliId);
        }

        [HttpPost]
        public async Task<dynamic> SaveClientes([FromBody] Clientes cliente) 
        {
            if (cliente.CliId != 0) 
            {
                return BadRequest(new {Message= "Inserte los campos correctamente"});
            }
            return await _clientesService.SaveClientes(cliente);
        }

        [HttpPut]
        public async Task<dynamic> UpdateClientes([FromBody] Clientes cliente) 
        {
            if (cliente.CliId == 0)
            {
                return BadRequest(new {Message= "Inserte el campo CliId para actualizar"});
            }
            return await _clientesService.SaveClientes(cliente);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteClients(int id)
        {
            await _clientesService.DeleteClientes(id);
        }
    }
}

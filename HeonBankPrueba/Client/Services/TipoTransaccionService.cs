using HeonBankPrueba.Shared;
using System.Text.Json;

namespace HeonBankPrueba.Client.Services
{
    public class TipoTransaccionService
    {
        private readonly string _apiUrl = "api/TipoTransaccion";
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions options;

        public TipoTransaccionService(HttpClient client) 
        { 
            _client= client;
        }

        public async Task<List<TipoTransaccion>> GetTipoTransaccion() 
        { 
            var response= await _client.GetAsync(_apiUrl);
            var content= await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<List<TipoTransaccion>>(content, options);
        }
    }
}

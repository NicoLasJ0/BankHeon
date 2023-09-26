using HeonBankPrueba.Shared;
using System.Text.Json;

namespace HeonBankPrueba.Client.Services
{
    public class TipoCuentaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "api/TipoCuenta";
        private readonly JsonSerializerOptions options;

        public TipoCuentaService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TipoCuenta>> GetTipoCuentas() 
        {
            var response = await _httpClient.GetAsync(_apiUrl);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<List<TipoCuenta>>(content, options);
        }

        public async Task<TipoCuenta> GetTipoCuenta(int id) 
        {
            var response = await _httpClient.GetAsync(_apiUrl + $"/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<TipoCuenta>(content, options);
        }
    
    }
}

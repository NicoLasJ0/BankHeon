using HeonBankPrueba.Shared;
using System.Text.Json;

namespace HeonBankPrueba.Client.Services
{
    public class BancosService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "api/Bancos";
        private readonly JsonSerializerOptions options;
        public BancosService(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
        }

        public async Task<List<Bancos>> GetBancos() 
        { 
            var response= await _httpClient.GetAsync(_apiUrl);
            var content= await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<List<Bancos>>(content, options);
        }

        public async Task<Bancos> GetBanco(int id) 
        {
            var response = await _httpClient.GetAsync(_apiUrl + $"/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<Bancos>(content, options);
        }
    }
}

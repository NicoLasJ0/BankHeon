using HeonBankPrueba.Shared;
using System.Text.Json;

namespace HeonBankPrueba.Client.Services
{
    public class FormaPagoService
    {
        private readonly string _apiUrl= "api/FormaPago";
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions options;

        public FormaPagoService(HttpClient client) 
        { 
            _client = client;
        }

        public async Task<List<FormaPago>> GetFormasPago() 
        { 
            var response = await _client.GetAsync(_apiUrl);
            var content= await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<List<FormaPago>>(content, options);
            
        }
    }
}

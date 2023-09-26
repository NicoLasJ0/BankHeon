using HeonBankPrueba.Client.Models;
using HeonBankPrueba.Shared;
using System.Net.Http.Json;
using System.Text.Json;

namespace HeonBankPrueba.Client.Services
{
    public class TransaccionService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl= "api/Transaccion";
        private readonly JsonSerializerOptions _options;

        public TransaccionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TransaccionDtoOut>>? GetTransacciones() 
        { 
            var response= await _httpClient.GetAsync(_apiUrl);
            var content= await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            Console.WriteLine(content);

            return JsonSerializer.Deserialize<List<TransaccionDtoOut>>(content, _options);
        }

        public async Task<TransaccionDtoOut> GetTransaccion(string id) 
        {
            var response = await _httpClient.GetAsync(_apiUrl + $"/{id}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<TransaccionDtoOut>(content, _options);
        }

        public async Task CreateTransaccion(Transaccion transaccion)
        {
            var response = await _httpClient.PostAsync(_apiUrl, JsonContent.Create(transaccion));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

        public async Task UpdateTransaccion(Transaccion transaccion)
        {
            var response = await _httpClient.PutAsync(_apiUrl, JsonContent.Create(transaccion));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

        public async Task DeleteTransaccion(string id)
        {
            var response = await _httpClient.DeleteAsync(_apiUrl + $"/{id}");
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

        }
    }
}

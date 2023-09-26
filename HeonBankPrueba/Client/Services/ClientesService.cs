using HeonBankPrueba.Client.Components.Clientes;
using HeonBankPrueba.Client.Models;
using HeonBankPrueba.Shared;
using System.Net.Http.Json;
using System.Text.Json;

namespace HeonBankPrueba.Client.Services
{
    public class ClientesService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "api/Clientes";
        private readonly JsonSerializerOptions options;
        public ClientesService(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
        }

        public async Task<List<ClienteDtoOut>>? GetClientes() 
        {

            var response = await _httpClient.GetAsync(_apiUrl);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            

            return  JsonSerializer.Deserialize<List<ClienteDtoOut>>(content, options);
        }

        public async Task<ClienteDtoOut>? GetCliente(string id) 
        {
            var response = await _httpClient.GetAsync(_apiUrl + $"/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<ClienteDtoOut>(content, options);
        }

        public async Task CreateClientes(Clientes cliente) 
        {
            var response = await _httpClient.PostAsync(_apiUrl, JsonContent.Create(cliente));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }
        public async Task UpdateProduct(Clientes cliente) 
        {
            var response = await _httpClient.PutAsync(_apiUrl, JsonContent.Create(cliente));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

        public async Task DeleteProduct(int id) 
        { 
            var response= await _httpClient.DeleteAsync(_apiUrl + $"/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) 
            {
                throw new ApplicationException(content);
            }  
        }
    }
}

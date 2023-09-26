using HeonBankPrueba.Client.Models;
using HeonBankPrueba.Shared;
using System.Net.Http.Json;
using System.Text.Json;

namespace HeonBankPrueba.Client.Services
{
    public class CuentaBancariaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiurl = "api/CuentaBancaria";
        private readonly JsonSerializerOptions options;
        public CuentaBancariaService(HttpClient httpClient) 
        { 
            this._httpClient = httpClient;
        }

        public async Task<List<CuentaBancariaDtoOut>>? GetCuentasBancarias() 
        { 
            var response= await _httpClient.GetAsync(this._apiurl);
            var content= await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<List<CuentaBancariaDtoOut>>(content, options);

        }

        public async Task<CuentaBancariaDtoOut>? GetCuentaBancaria(string id) 
        {
            var response = await _httpClient.GetAsync(this._apiurl + $"/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode) 
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<CuentaBancariaDtoOut>(content, options);
        }

        public async Task CreateCuentaBancaria(CuentaBancaria cuentaBancaria) 
        {
            var response = await _httpClient.PostAsync(this._apiurl, JsonContent.Create(cuentaBancaria));
            var content = await response.Content.ReadAsStringAsync();

            Console.WriteLine(content);
            if (!response.IsSuccessStatusCode) 
            {
                throw new ApplicationException(content);
            }
        }

        public async Task UpdateCuentaBancaria(CuentaBancaria cuentaBancaria) 
        {
            var response = await _httpClient.PutAsync(this._apiurl, JsonContent.Create(cuentaBancaria));
            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
        }

        public async Task DeleteCuentaBancaria(int id) 
        {
            var response = await _httpClient.DeleteAsync(this._apiurl + $"/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

        }



    }
}

using HeonBankPrueba.Shared;
using System.Text.Json;

namespace HeonBankPrueba.Client.Services
{
    public class TipoIdentificacionService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "api/TipoIdentificacion";
        private readonly JsonSerializerOptions options;

        public TipoIdentificacionService(HttpClient httpClient) 
        { 
            this._httpClient = httpClient;
        }

        public async Task<List<TipoIdentificacion>>? GetTipoIdentificacion() 
        { 
            var response= await _httpClient.GetAsync(_url);
            var content= await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

            return JsonSerializer.Deserialize<List<TipoIdentificacion>>(content, options);
        } 
    }
}

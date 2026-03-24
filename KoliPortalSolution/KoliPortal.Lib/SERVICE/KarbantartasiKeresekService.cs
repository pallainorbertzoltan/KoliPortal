using KoliPortal.Lib.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace KoliPortal.Lib.SERVICE
{
    public class KarbantartasiKeresekService
    {
        private readonly HttpClient _httpClient;
        public KarbantartasiKeresekService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<KarbantartasiKeresek>> GetKarbantartasiKeresek(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.GetFromJsonAsync<List<KarbantartasiKeresek>>("api/KarbantartasiKeresek") ?? new List<KarbantartasiKeresek>();
        }

        public async Task DeleteKarbantartasiKeresek(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.DeleteAsync($"api/KarbantartasiKeresek/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateKarbantartasiKeresek(KarbantartasiKeresek adat,string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PutAsJsonAsync($"api/KarbantartasiKeresek", adat);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateKarbantartasiKeresek(KarbantartasiKeresek adat, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsJsonAsync("api/KarbantartasiKeresek", adat);
            response.EnsureSuccessStatusCode();
        }
    }
} 

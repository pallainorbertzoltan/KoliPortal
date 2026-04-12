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
    public class SzobaBeosztasokService
    {
        private readonly HttpClient _httpClient;
        public SzobaBeosztasokService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<SzobaBeosztasok>> GetSzobaBeosztasok(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.GetFromJsonAsync<List<SzobaBeosztasok>>("api/SzobaBeosztasok") ?? new List<SzobaBeosztasok>();
        }
        public async Task UpdateSzobaBeosztasok(SzobaBeosztasok adat, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.PutAsJsonAsync("api/SzobaBeosztasok", adat);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateSzobaBeosztasok(SzobaBeosztasok adatok, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsJsonAsync("api/SzobaBeosztasok", adatok);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteSzobaBeosztasok(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.DeleteAsync($"api/SzobaBeosztasok/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

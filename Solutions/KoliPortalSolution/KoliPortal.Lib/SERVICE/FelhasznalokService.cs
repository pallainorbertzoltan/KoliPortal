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
    public class FelhasznalokService
    {
        private readonly HttpClient _httpClient;
        public FelhasznalokService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Felhasznalok>> GetFelhasznalok(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.GetFromJsonAsync<List<Felhasznalok>>("api/Felhasznalok") ?? new List<Felhasznalok>();
        }

        public async Task UpdateFelhasznalok(Felhasznalok adat, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PutAsJsonAsync("api/Felhasznalok", adat);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteFelhasznalok(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.DeleteAsync($"api/Felhasznalok/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateFelhasznalok(Felhasznalok adat, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsJsonAsync("api/Felhasznalok", adat);
            response.EnsureSuccessStatusCode();
        }
    }
}

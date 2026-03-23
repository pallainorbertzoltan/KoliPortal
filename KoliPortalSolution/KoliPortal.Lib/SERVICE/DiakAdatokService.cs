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
    public class DiakAdatokService
    {
        private readonly HttpClient _httpClient;
        public DiakAdatokService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<DiakAdatok>> GetDiakAdatok(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.GetFromJsonAsync<List<DiakAdatok>>("api/DiakAdatok") ?? new List<DiakAdatok>();
        }

        public async Task<DiakAdatok?> GetByIdAsync(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.GetFromJsonAsync<DiakAdatok>($"api/DiakAdatok/{id}");
        }

        public async Task UpdateDiakAdatok(DiakAdatok adat, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PutAsJsonAsync("api/DiakAdatok", adat);
            response.EnsureSuccessStatusCode();
        }

        public async Task CreateDiakAdatok(DiakAdatok adat, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsJsonAsync("api/DiakAdatok", adat);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteDiakAdatok(int id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.DeleteAsync($"api/DiakAdatok/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

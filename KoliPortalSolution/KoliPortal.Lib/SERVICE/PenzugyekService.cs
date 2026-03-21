using KoliPortal.Lib.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace KoliPortal.Lib.SERVICE
{
    public class PenzugyekService
    {
        private readonly HttpClient _httpClient;
        public PenzugyekService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<Penzugyek>> GetPenzugyek()
        {
            return await _httpClient.GetFromJsonAsync<List<Penzugyek>>("api/Penzugyek") ?? new List<Penzugyek>();
        }

        public async Task DeletePenzugyek(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Penzugyek/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}

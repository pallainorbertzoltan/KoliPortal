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
    public class FizetesTipusokService
    {
        private readonly HttpClient _httpClient;
        public FizetesTipusokService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<FizetesTipusok>> GetFizetesTipusok(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.GetFromJsonAsync<List<FizetesTipusok>>("api/FizetesTipusok") ?? new List<FizetesTipusok>();
        }
    }
}

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
    public class KollegiumService
    {
        private readonly HttpClient _httpClient;
        public KollegiumService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<Kollegium>> GetKollegium(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.GetFromJsonAsync<List<Kollegium>>("api/Kollegium") ?? new List<Kollegium>();
        }
    }
}

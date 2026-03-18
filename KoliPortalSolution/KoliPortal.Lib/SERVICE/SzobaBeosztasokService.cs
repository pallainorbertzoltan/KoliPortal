using KoliPortal.Lib.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<SzobaBeosztasok>> GetSzobaBeosztasok()
        {
            return await _httpClient.GetFromJsonAsync<List<SzobaBeosztasok>>("api/SzobaBeosztasok") ?? new List<SzobaBeosztasok>();
        }
    }
}

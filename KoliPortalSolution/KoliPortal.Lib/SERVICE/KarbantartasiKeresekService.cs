using KoliPortal.Lib.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<KarbantartasiKeresek>> GetKarbantartasiKeresek()
        {
            return await _httpClient.GetFromJsonAsync<List<KarbantartasiKeresek>>("api/KarbantartasiKeresek") ?? new List<KarbantartasiKeresek>();
        }
    }
} 

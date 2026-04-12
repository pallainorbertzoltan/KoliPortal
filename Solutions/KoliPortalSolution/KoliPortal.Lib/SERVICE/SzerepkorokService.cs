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
    public class SzerepkorokService
    {
        private readonly HttpClient _httpClient;
        public SzerepkorokService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Szerepkorok>> GetSzerepkorok(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await _httpClient.GetFromJsonAsync<List<Szerepkorok>>("api/Szerepkorok") ?? new List<Szerepkorok>();
        }
    }
}

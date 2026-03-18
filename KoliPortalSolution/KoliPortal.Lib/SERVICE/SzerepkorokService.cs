using KoliPortal.Lib.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<List<Szerepkorok>> GetSzerepkorok()
        {
            return await _httpClient.GetFromJsonAsync<List<Szerepkorok>>("api/Szerepkorok") ?? new List<Szerepkorok>();
        }
    }
}

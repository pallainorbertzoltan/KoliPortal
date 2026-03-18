using KoliPortal.Lib.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<DiakAdatok>> GetDiakAdatok()
        {
            return await _httpClient.GetFromJsonAsync<List<DiakAdatok>>("api/DiakAdatok") ?? new List<DiakAdatok>();
        }

        public async Task<DiakAdatok?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<DiakAdatok>($"api/DiakAdatok/{id}");
        }


    }
}

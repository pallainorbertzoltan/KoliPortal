using KoliPortal.Lib.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace KoliPortal.Lib.SERVICE
{
    public class SzobakService
    {
        private readonly HttpClient _httpClient;
        public SzobakService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<Szobak>> GetSzobak()
        {
            return await _httpClient.GetFromJsonAsync<List<Szobak>>("api/Szobak") ?? new List<Szobak>();
        }

        public async Task<Szobak?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Szobak>($"api/Szobak/{id}");
        }
    }
}

using KoliPortal.Lib.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace KoliPortal.Lib.SERVICE
{
    public class FelhasznalokService
    {
        private readonly HttpClient _httpClient;
        public FelhasznalokService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Felhasznalok>> GetFelhasznalok()
        {
            return await _httpClient.GetFromJsonAsync<List<Felhasznalok>>("api/Felhasznalok") ?? new List<Felhasznalok>();
        }
    }
}

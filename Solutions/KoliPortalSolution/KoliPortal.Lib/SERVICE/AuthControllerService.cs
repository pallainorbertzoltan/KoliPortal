using KoliPortal.Lib.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KoliPortal.Lib.SERVICE
{
    public class AuthControllerService
    {
        public readonly HttpClient _httpClient;

        public AuthControllerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> RegisterAsync(Felhasznalok ujUser, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsJsonAsync("api/Auth/Register", ujUser);
            return response.IsSuccessStatusCode;
        }

        public async Task<string> LoginAsync(Login loginAdat)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Auth/Login", loginAdat);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadFromJsonAsync<JsonElement>();

                // Megpróbáljuk megkeresni benne a "Token" vagy "token" kulcsot
                if (json.TryGetProperty("token", out var tokenValue) || json.TryGetProperty("Token", out tokenValue))
                {
                    return tokenValue.GetString() ?? string.Empty;
                }
            }

            return string.Empty;
        }
    }
}

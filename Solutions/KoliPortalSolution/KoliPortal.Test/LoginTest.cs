using Bunit;
using KoliPortal.Lib.SERVICE;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Xunit;
using KoliPortal.Web.Components.Pages.LOGIN;
using Moq;
using Microsoft.AspNetCore.Components;

namespace KoliPortal.Tests
{
    public class LoginTests : TestContext
    {
        [Fact]
        public void Login_UresAdatokkal_ValidaciosHibatDob()
        {
            // Regisztráljuk a szervizt egy üres HTTP klienssel. 
            var dummyHttp = new HttpClient();
            Services.AddSingleton(new AuthControllerService(dummyHttp));

            // Regisztráljuk a navigáció figyelőt
            Services.GetRequiredService<NavigationManager>();

            var cut = Render<Login>();

            // Megkeressük a bejelentkezés gombot (type="submit")
            var loginGomb = cut.Find("button[type='submit']");

            // Rákattintunk a gombra úgy, hogy az Email és Jelszó mezők teljesen üresek
            loginGomb.Click();

            // Megkeressük az oldalon felugró piros hibaüzenet dobozt
            var hibaDoboz = cut.Find(".alert-danger");

            // Ellenőrizzük, hogy valóban az űrlap validációs hibája jelenik-e meg és nem próbálta meg elküldeni az üres kérést az API-nak.
            Assert.Contains("Kérlek tölts ki minden mezőt!", hibaDoboz.TextContent);
        }

        [Fact]
        public void Login_VisszaGomb_JoHelyreMutat()
        {
            var dummyHttp = new HttpClient();
            Services.AddSingleton(new AuthControllerService(dummyHttp));
            Services.GetRequiredService<NavigationManager>();

            var cut = Render<Login>();

            // Megkeressük a "Vissza a kezdőlapra" linket az ikonja melletti szöveg alapján
            var visszaLink = cut.Find("a[href='/']");

            // Ellenőrizzük, hogy tényleg van-e ilyen link, és jó helyre visz-e
            Assert.NotNull(visszaLink);
            Assert.Contains("Vissza a kezdőlapra", visszaLink.TextContent);
        }
    }
}
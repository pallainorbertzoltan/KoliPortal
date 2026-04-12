using Bunit;
using Bunit.TestDoubles;
using KoliPortal.Lib.SERVICE;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Xunit;
using KoliPortal.Web.Components.Pages.LAKO;
using Moq;
using Microsoft.AspNetCore.Components;

namespace KoliPortal.Tests
{
    public class LakoTest : TestContext
    {
        [Fact]
        public void LakoOldal_RosszSzerepkorEseten_VisszadobAFooldalra()
        {
            // Létrehozunk egy érvényes tokent, de direkt "admin" szerepkörrel, hogy megnézzük, a Lakó oldal kidobja-e a hívatlan vendéget.
            string adminJwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyAicm9sZSI6ICJhZG1pbiIgfQ.dummy";

            var jsInterop = JSInterop.Setup<string>("localStorage.getItem", "authToken");
            jsInterop.SetResult(adminJwtToken);

            // Regisztráljuk a szervizeket
            var dummyHttp = new HttpClient();
            Services.AddSingleton(new SzobakService(dummyHttp));
            Services.AddSingleton(new KarbantartasiKeresekService(dummyHttp));
            Services.AddSingleton(new SzobaBeosztasokService(dummyHttp));
            Services.AddSingleton(new PenzugyekService(dummyHttp));
            Services.AddSingleton(new FizetesTipusokService(dummyHttp));

            // Bekérjük a navigáció-figyelőt
            var navMan = Services.GetRequiredService<NavigationManager>();

            // Megpróbáljuk betölteni az oldalt az Admin tokenünkkel
            var cut = Render<Attekintes>();

            // Ellenőrizzük, hogy a kód felismerte a jogosulatlan behatolást, és a NavigationManager-ben rögzítette, hogy átirányított a "http://localhost/" URL-re.
            Assert.Equal("http://localhost/", navMan.Uri);
        }

        [Fact]
        public void SzandekosanHibasTeszt_SikeresFizetesUzenetetKeres_IndulasKor()
        {
            // Készítünk egy JWT tokent, amiben a szerepkör "lako" (hogy ne dobjon ki a főoldalra)
            string lakoJwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyAicm9sZSI6ICJsYWtvIiwgImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjogIjEiIH0.dummy";

            var jsInterop = JSInterop.Setup<string>("localStorage.getItem", "authToken");
            jsInterop.SetResult(lakoJwtToken);

            var dummyHttp = new HttpClient();
            Services.AddSingleton(new PenzugyekService(dummyHttp));
            Services.AddSingleton(new FizetesTipusokService(dummyHttp));
            Services.GetRequiredService<NavigationManager>();

            // Rendereljük az oldalt
            var cut = Render<Befizetesek>();

            // Megvárjuk, amíg a kód befejezi a kamu adatok betöltését ami most egy üres lista lesz
            cut.WaitForState(() => cut.FindAll(".spinner-border").Count == 0);

            // A teszt megpróbálja megtalálni a ".alert-success" (zöld értesítés) HTML elemet.
            // Mivel a "sikeresFizetes" változó alapértelmezetten FALSE, ez az elem NINCS a képernyőn.
            // A bUnit itt azonnal eldobja a tesztet egy hibával!
            var successAlert = cut.Find(".alert-success");

            // (Ez a sor már le sem fog futni a fenti hiba miatt)
            Assert.Contains("Sikeres tranzakció", successAlert.TextContent);
        }

        [Fact]
        public void Hibajelentes_UresUrlapKuldese_ValidaciosHibatDob()
        {
            // Létrehozunk egy érvényes "lako" tokent (hogy ne dobjon ki az oldal)
            string lakoJwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyAicm9sZSI6ICJsYWtvIiwgImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWVpZGVudGlmaWVyIjogIjEiIH0.dummy";

            var jsInterop = JSInterop.Setup<string>("localStorage.getItem", "authToken");
            jsInterop.SetResult(lakoJwtToken);

            // Regisztráljuk a szervizeket a kamu HTTP klienssel
            var dummyHttp = new HttpClient();
            Services.AddSingleton(new KarbantartasiKeresekService(dummyHttp));
            Services.AddSingleton(new KarbantartasStatuszokService(dummyHttp));

            Services.GetRequiredService<NavigationManager>();

            var cut = Render<Hibajelentes>();

            // Megvárjuk, amíg az indulási adatok "betöltenek" és eltűnik a pörgő ikon
            cut.WaitForState(() => cut.FindAll(".spinner-border").Count == 0);

            // Megkeressük a "Jelentés küldése" gombot a formon belül
            var kuldesGomb = cut.Find("form button[type='submit']");

            // Rákattintunk a gombra úgy, hogy nem írtunk be semmit!
            kuldesGomb.Click();

            // Megkeressük az oldalon a felugró piros hibaüzenetet (.alert-danger)
            var hibaDoboz = cut.Find(".alert-danger");

            // Ellenőrizzük, hogy tényleg a megírt figyelmeztetés jelent-e meg
            Assert.Contains("Kérlek, válassz egy hiba típust a listából!", hibaDoboz.TextContent);
        }
    }
}
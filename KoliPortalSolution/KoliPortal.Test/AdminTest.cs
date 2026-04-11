using Bunit;
using Bunit.TestDoubles;
using KoliPortal.Lib.SERVICE;
using KoliPortal.Web.Components.Pages.ADMIN;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace KoliPortal.Tests
{
    public class AdminTests : TestContext
    {
        [Fact]
        public void OnAfterRenderAsync_HaNincsToken_AtiranyitAKezdolapra()
        {

            // Szimuláljuk a JavaScript futtatót: megmondjuk neki, hogy ha a kód a "localStorage.getItem"-et hívja, adjon vissza egy üres stringet (nincs token).
            var jsInterop = JSInterop.Setup<string>("localStorage.getItem", "authToken");
            jsInterop.SetResult("");

            // Létrehozunk egy üres HttpClient-et, amit a Moq odaadhat a szervizeidnek.
            var dummyHttp = new HttpClient();

            // Szimuláljuk a szervizeket
            Services.AddSingleton(new Mock<SzobakService>(dummyHttp).Object);
            Services.AddSingleton(new Mock<KarbantartasiKeresekService>(dummyHttp).Object);
            Services.AddSingleton(new Mock<SzobaBeosztasokService>(dummyHttp).Object);
            Services.AddSingleton(new Mock<FelhasznalokService>(dummyHttp).Object);
            Services.AddSingleton(new Mock<PenzugyekService>(dummyHttp).Object);

            // Bekérjük a bUnit beépített, hamis NavigationManager-ét, ami figyeli az átirányításokat.
            var navMan = Services.GetRequiredService<NavigationManager>();

            // Rendereljük az oldalt. 
            var cut = Render<Attekintes>();

            // Megnézzük, hogy a @code blokkban lévő Nav.NavigateTo("/") parancs lefutott-e.
            Assert.Equal("http://localhost/", navMan.Uri);
        }

        [Fact]
        public void FelhasznalokOldal_Indulaskor_MegjelenikABetoltoKepernyo()
        {

            var dummyHttp = new HttpClient();

            Services.AddSingleton(new FelhasznalokService(dummyHttp));
            Services.AddSingleton(new SzerepkorokService(dummyHttp));
            Services.AddSingleton(new SzobaBeosztasokService(dummyHttp));
            Services.AddSingleton(new SzobakService(dummyHttp));
            Services.AddSingleton(new DiakAdatokService(dummyHttp));
            Services.AddSingleton(new KarbantartasiKeresekService(dummyHttp));
            Services.AddSingleton(new PenzugyekService(dummyHttp));
            Services.AddSingleton(new KollegiumService(dummyHttp));

            Services.GetRequiredService<NavigationManager>();

            // Rendereljük az oldalt. 
            var cut = Render<KoliPortal.Web.Components.Pages.ADMIN.Felhasznalok>();

            // Megkeressük a pörgő ikont (spinner)
            var spinner = cut.Find("spinner-border");
            Assert.NotNull(spinner);

            // Ellenőrizzük, hogy a pörgő ikon alatti szöveg megfelelő-e
            var loadingText = cut.Find("p.text-muted").TextContent;
            Assert.Contains("Felhasználók betöltése...", loadingText);
        }

        [Fact]
        public void KarbantartasOldal_UresAdatbazisEseten_MegjelennekAzUresAllapotUzenetek()
        {

            // Átverjük a JavaScript hívást a kamu Admin tokennel
            string kamuJwtToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyAicm9sZSI6ICJhZG1pbiIgfQ.dummy";
            var jsInterop = JSInterop.Setup<string>("localStorage.getItem", "authToken");
            jsInterop.SetResult(kamuJwtToken);

            // Szervizek regisztrálása egy HTTP klienssel
            var dummyHttp = new HttpClient();

            Services.AddSingleton(new KarbantartasiKeresekService(dummyHttp));
            Services.AddSingleton(new KarbantartasStatuszokService(dummyHttp));
            Services.AddSingleton(new FelhasznalokService(dummyHttp));
            Services.AddSingleton(new SzobaBeosztasokService(dummyHttp));
            Services.AddSingleton(new SzobakService(dummyHttp));

            Services.GetRequiredService<NavigationManager>();

            // Rendereljük az oldalt (Feltételezem, hogy Karbantartas.razor a fájl neve)
            var cut = Render<Karbantartas>();

            // Mivel a betöltés aszinkron (Task), meg kell várnunk, amíg a kódod befejezi a "töltést" és a betoltesAlatt változó false lesz (azaz eltűnik a pörgő ikon).
            cut.WaitForState(() => cut.FindAll(".spinner-border").Count == 0);

            // Ellenőrizzük az Aktuális Feladatok táblázatát
            // Megkeressük az első táblázat (aktív hibák) celláit
            var aktivHibakCella = cut.Find("table tbody tr td");
            Assert.Contains("Jelenleg nincs aktív hibajegy", aktivHibakCella.TextContent);

            // Ellenőrizzük az Előzmények szekciót
            // Megkeressük az '.empty-state-card' osztályú elemet
            var elozmenyekUresKartyaja = cut.Find(".empty-state-card");
            Assert.Contains("Még nincs megjeleníthető előzmény", elozmenyekUresKartyaja.TextContent);
        }

        [Fact]
        public void KarbantartasOldal_Indulaskor_MegjelenikABetoltoKepernyo()
        {
            // Beállítjuk a JSInterop-ot, de direkt NEM hívjuk meg a .SetResult() metódust!
            // Emiatt az "await JS.InvokeAsync..." sor végtelen ideig fog várakozni így az oldal garantáltan a "Betöltés alatt" állapotban marad!
            JSInterop.Setup<string>("localStorage.getItem", "authToken");

            var dummyHttp = new HttpClient();
            Services.AddSingleton(new KarbantartasiKeresekService(dummyHttp));
            Services.AddSingleton(new KarbantartasStatuszokService(dummyHttp));
            Services.AddSingleton(new FelhasznalokService(dummyHttp));
            Services.AddSingleton(new SzobaBeosztasokService(dummyHttp));
            Services.AddSingleton(new SzobakService(dummyHttp));
            Services.GetRequiredService<NavigationManager>();

            var cut = Render<Karbantartas>();

            // Megkeresi aa '.spinner-border'-t, mert "megállt" a töltés pillanatában!
            var spinner = cut.Find(".spinner-border");
            Assert.NotNull(spinner);

            var loadingText = cut.Find("p.text-muted").TextContent;
            Assert.Contains("Hibajegyek letöltése...", loadingText);
        }
    }
}
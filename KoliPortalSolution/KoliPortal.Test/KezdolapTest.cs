using Bunit;
using Xunit;
using KoliPortal.Web.Components.Pages.KEZDOLAP;
using KoliPortal.Web.Components.Layout;

namespace KoliPortal.Tests
{
    public class KezdolapTests : TestContext
    {
        [Fact]
        public void HamburgerGomb_TartalmazzaAZUjStilusOsztalyt()
        {
            // Rendereljük az oldalt. 
            var cut = Render<Kezdolap>();

            // Megkeressük a gombot (a Bootstrap osztály alapján)
            var hamburgerButton = cut.Find("button.navbar-toggler");

            // Ellenõrizzük, hogy az egyedi "hamburger-btn" stílus rákerült-e
            Assert.Contains("hamburger-btn", hamburgerButton.ClassName);

            // Azt is megnézzük, hogy a shadow-none is rajta van-e
            Assert.Contains("shadow-none", hamburgerButton.ClassName);
        }

        [Fact]
        public void BejelentkezesGomb_AJoOldalraIranyit()
        {
            // Rendereljük az oldalt. 
            var cut = Render<Kezdolap>();

            // Megkeressük a bejelentkezés gombot
            var loginLink = cut.Find("a.login-btn");

            // Ellenõrizzük, hogy a href attribútum pontosan a /login-ra mutat-e
            Assert.Equal("/login", loginLink.GetAttribute("href"));
        }

        [Fact]
        public void Menupontok_MindenHivatkozasMegjelenikE()
        {
            // Rendereljük az oldalt. 
            var cut = Render<Kezdolap>();

            // Megkeressük az összes "nav-link" osztályú elemet
            var navLinks = cut.FindAll(".nav-link");

            // Ellenõrizzük, hogy pontosan 3 darab van-e belõlük
            Assert.Equal(3, navLinks.Count);

            // Ellenõrizzük, hogy a megfelelõ szövegeket tartalmazzák-e
            Assert.Contains(navLinks, link => link.TextContent.Contains("Rólunk"));
            Assert.Contains(navLinks, link => link.TextContent.Contains("Funkciók"));
            Assert.Contains(navLinks, link => link.TextContent.Contains("Kapcsolat"));
        }

        [Fact]
        public void HamburgerGomb_MegfeleloenVanEBeallitvaABootstraphez()
        {
            // Rendereljük az oldalt. 
            var cut = Render<Kezdolap>();

            // Megkeressük a gombot és a lenyíló menüt
            var button = cut.Find("button.navbar-toggler");
            var collapseDiv = cut.Find("div.navbar-collapse");

            // A gomb "data-bs-target" attribútumának a menü ID-jére kell mutatnia
            var targetId = button.GetAttribute("data-bs-target");
            var divId = collapseDiv.Id;

            // Ellenõrizzük, hogy a gomb a #koliNavbar-ra mutat-e, és a div ID-je koliNavbar-e
            Assert.Equal("#koliNavbar", targetId);
            Assert.Equal("koliNavbar", divId);
        }
    }
}
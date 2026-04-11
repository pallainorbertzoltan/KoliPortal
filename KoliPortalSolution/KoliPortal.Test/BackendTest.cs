using KoliPortal.API.Controllers;
using KoliPortal.API.INTERFACE;
using KoliPortal.API.SERVICE;
using KoliPortal.Lib.DATA;
using KoliPortal.Lib.MODEL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace KoliPortal.Tests.Backend
{
    public class DiakAdatokControllerTests
    {
        [Fact]
        public async Task GetAll_VisszaadjaAzOsszesDiakAdatot_Http200OkValasszal()
        {

            // Létrehozzuk a szerviz interfész (IDiakAdatok) másolatát
            var mockService = new Mock<IDiakAdatok>();

            // Csinálunk egy teszt listát 2 kamu diákkal
            var tesztLista = new List<DiakAdatok>
            {
                new DiakAdatok { UserID = 1 },
                new DiakAdatok { UserID = 2 }
            };

            // Megtanítjuk a klónnak, hogy ha a Controller meghívja a GetAll() metódusát, akkor ne az adatbázisba menjen, hanem azonnal adja vissza a fenti teszt listát!
            mockService.Setup(service => service.GetAll()).ReturnsAsync(tesztLista);

            // Példányosítjuk a Controllert, és a konstruktorán keresztül "beoltjuk" a hamis szervizzel
            var controller = new DiakAdatokController(mockService.Object);

            // Meghívjuk a végpontot (mintha egy böngésző vagy a Blazor küldene egy HTTP GET kérést)
            var actionResult = await controller.GetAll();

            // Megnézzük, hogy tényleg HTTP 200 jött-e vissza
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);

            // Kicsomagoljuk a választ, és megnézzük, hogy az adat tényleg egy diákokból álló lista-e
            var kapottDiakok = Assert.IsType<List<DiakAdatok>>(okResult.Value);

            // Ellenőrizzük, hogy a listában pontosan 2 elem van-e (amit az Arrange részben megadtunk)
            Assert.Equal(2, kapottDiakok.Count);
        }

        [Fact]
        public async Task Felhasznalok_Create_VisszaadjaAzUjIdt_Http200OkValasszal()
        {
            var mockService = new Mock<IFelhasznalok>();
            var ujFelhasznalo = new Felhasznalok { ID = 99, Nev = "Új Diák" };

            // Beállítjuk, hogy az Add metódus sikeresen lefusson
            mockService.Setup(s => s.Add(ujFelhasznalo)).ReturnsAsync(ujFelhasznalo);
            var controller = new FelhasznalokController(mockService.Object);

            var actionResult = await controller.Create(ujFelhasznalo);

            // Ellenőrizzük, hogy HTTP 200 OK jött-e vissza, és benne van-e az új ID (99)
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.Equal(99, okResult.Value);
        }

        [Fact]
        public async Task FizetesTipusok_GetAll_VisszaadjaATipusokat_Http200OkValasszal()
        {
            var mockService = new Mock<IFizetesTipusok>();
            var tesztLista = new List<FizetesTipusok>
            {
                new FizetesTipusok { ID = 1, Megnevezes = "Kollégiumi díj" },
                new FizetesTipusok { ID = 2, Megnevezes = "Kártérítés" }
            };
            mockService.Setup(s => s.GetAll()).ReturnsAsync(tesztLista);
            var controller = new FizetesTipusokController(mockService.Object);

            var actionResult = await controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var kapottLista = Assert.IsType<List<FizetesTipusok>>(okResult.Value);
            Assert.Equal(2, kapottLista.Count); // Pontosan 2 elemet várunk
        }

        [Fact]
        public async Task KarbantartasiKeresek_Delete_TorlesEseten_Http204NoContentValasztAd()
        {
            var mockService = new Mock<IKarbantartasiKeresek>();
            // A Delete metódus nem ad vissza értéket, csak lefut (Task.CompletedTask)
            mockService.Setup(s => s.Delete(5)).Returns(Task.CompletedTask);
            var controller = new KarbantartasiKeresekController(mockService.Object);

            var actionResult = await controller.Delete(5); // Megpróbáljuk törölni az 5-ös ID-t

            // Sikeres törlésnél az API szabvány szerint HTTP 204 No Content-nek kell visszajönnie
            Assert.IsType<NoContentResult>(actionResult);
        }

        [Fact]
        public async Task KarbantartasStatuszok_GetAll_VisszaadjaAStatuszokat_Http200OkValasszal()
        {
            var mockService = new Mock<IKarbantartasStatuszok>();
            var tesztLista = new List<KarbantartasStatuszok>
            {
                new KarbantartasStatuszok { ID = 1, Nev = "Új" }
            };
            mockService.Setup(s => s.GetAll()).ReturnsAsync(tesztLista);
            var controller = new KarbantartasStatuszokController(mockService.Object);

            var actionResult = await controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var kapottLista = Assert.IsType<List<KarbantartasStatuszok>>(okResult.Value);
            Assert.Single(kapottLista); // Assert.Single ellenőrzi, hogy pontosan 1 elem van-e a listában
        }

        [Fact]
        public async Task Kollegium_GetAll_VisszaadjaAKollegiumokat_Http200OkValasszal()
        {
            var mockService = new Mock<IKollegium>();
            var tesztLista = new List<Kollegium> { new Kollegium { ID = 1, KollegiumNev = "Karinthy" } };
            mockService.Setup(s => s.GetAll()).ReturnsAsync(tesztLista);
            var controller = new KollegiumController(mockService.Object);

            var actionResult = await controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.IsType<List<Kollegium>>(okResult.Value);
        }

        [Fact]
        public async Task Penzugyek_Update_SikeresModositasEseten_Http204NoContentValasztAd()
        {
            var mockService = new Mock<IPenzugyek>();
            var modositottTetel = new Penzugyek { ID = 10, Osszeg = 5000 };
            mockService.Setup(s => s.Update(modositottTetel)).Returns(Task.CompletedTask);
            var controller = new PenzugyekController(mockService.Object);

            var actionResult = await controller.Update(modositottTetel);

            Assert.IsType<NoContentResult>(actionResult);
        }

        [Fact]
        public async Task Szerepkorok_GetAll_VisszaadjaASzerepkorokListajat()
        {
            var mockService = new Mock<ISzerepkorok>();
            var tesztLista = new List<Szerepkorok> { new Szerepkorok { ID = 1, Nev = "Admin" } };
            mockService.Setup(s => s.GetAll()).ReturnsAsync(tesztLista);
            var controller = new SzerepkorokController(mockService.Object);

            var actionResult = await controller.GetAll();

            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task SzobaBeosztasok_Create_SikeresLetrehozas_VisszaadjaAzIdt()
        {
            var mockService = new Mock<ISzobaBeosztasok>();
            var ujBeosztas = new SzobaBeosztasok { ID = 42, RoomID = 101, UserID = 5 };
            mockService.Setup(s => s.Add(ujBeosztas)).ReturnsAsync(ujBeosztas);
            var controller = new SzobaBeosztasokController(mockService.Object);

            var actionResult = await controller.Create(ujBeosztas);

            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.Equal(42, okResult.Value); // Ellenőrizzük, hogy a 42-es ID jött-e vissza
        }

        [Fact]
        public async Task Szobak_GetAll_LekeriASzobakListajat()
        {
            var mockService = new Mock<ISzobak>();
            var tesztLista = new List<Szobak> { new Szobak { ID = 1, Szobaszam = "101" } };
            mockService.Setup(s => s.GetAll()).ReturnsAsync(tesztLista);
            var controller = new SzobakController(mockService.Object);

            var actionResult = await controller.GetAll();

            Assert.IsType<OkObjectResult>(actionResult.Result);
        }
    }
}
# 🏢 KoliPortál - Vizsgaremek

A **KoliPortál** egy modern, reszponzív, webes alapú kollégiumi adminisztrációs és ügyviteli rendszer, amely a vizsgaremek projektünk keretében készült. Célja a kollégiumi lakók és az adminisztrátorok mindennapi feladatainak (szobabeosztás, hibabejelentés, pénzügyek) digitalizálása és egyszerűsítése.

## 👥 Projektmunka tagjai:
* **Kercsó Norbert**
* **Pallai Norbert Zoltán**

## 💻 Felhasznált technológiák
A projekt modern Microsoft technológiai stackre épül, követve a reszponzív webdesign elveit:
* **Frontend & Backend:** C# .NET 8 (Blazor Web App)
* **Adatbázis:** Microsoft SQL Server
* **Megjelenés (UI):** HTML5, CSS3, Bootstrap 5, Bootstrap Icons
* **Verziókövetés:** Git & GitHub

## ✨ Főbb funkciók és modulok
A rendszer szerepkör-alapú jogosultságkezeléssel (Adminisztrátor / Lakó) rendelkezik.

**Lakók (Diákok) számára:**
* 🔐 Biztonságos bejelentkezés (JWT token alapú azonosítás)
* 📊 Átlátható műszerfal (Dashboard) a saját adatokkal
* 🛠️ **Hibabejelentés:** Gyors és kategóriákra bontott műszaki hibajelentés leadása
* 💰 **Pénzügyek:** Aktuális kollégiumi díjak, tartozások és befizetési előzmények megtekintése

**Adminisztrátorok számára:**
* 🛏️ **Szobakezelés:** Ágyak, férőhelyek vizuális áttekintése, kapacitásfigyelés
* 🔄 **Költöztetés:** Diákok be- és kiköltöztetése, lakhatási history (előzmény) vezetése
* 📝 **Hibajegyek kezelése:** A diákok által leadott bejelentések állapotának (Új/Folyamatban/Kész) frissítése
* 💳 **Pénzügyi adminisztráció:** Díjak kiírása és befizetések jóváhagyása

## 🚀 Futtatás helyi környezetben (Lokálisan)
A projekt futtatásához az alábbi lépések szükségesek:
1. A repository klónozása: `git clone https://github.com/pallainorbertzoltan/KoliPortal`
2. A projekt megnyitása **Visual Studio 2022** környezetben.
3. Az adatbázis létrehozása a mellékelt SQL szkript (vagy Entity Framework Migrations) segítségével az SSMS-ben.
4. Az `appsettings.json` fájlban a `DefaultConnection` adatbázis-kapcsolati karakterlánc (Connection String) beállítása a helyi SQL szerverhez.
5. A projekt elindítása (F5 / IIS Express / Kestrel).

## 📄 Dokumentáció
A projekt részletes tervezési, adatbázis- és fejlesztői dokumentációja megtalálható a vizsgaremekhez mellékelt hivatalos Word/PDF dokumentumokban.

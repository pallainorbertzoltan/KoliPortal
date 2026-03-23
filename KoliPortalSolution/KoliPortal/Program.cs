
using KoliPortal.API.AuthService;
using KoliPortal.API.INTERFACE;
using KoliPortal.API.SERVICE;
using KoliPortal.Lib.DATA;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

namespace KoliPortal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<KoliportalDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            // A token tulajdonsagainak beallitasa a konfiguracios fajlbol peldaul a JWT kulcs, issuer, audience es lejarati ido beallitasa a JWTTokenService szolgaltatasban.
            var jwtSettings = builder.Configuration.GetSection("Jwt");

            // Jwt Scheme beallitasa a hitelesiteshet, amely meghatarozza, hogy a JWT tokeneket hogyan kell kezelni es ervenyesiteni az alkalmazasba.

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // Alapveto hitelesitesi sema beallitasa a JWT Bearer sema hasznalata.
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // Alapveto kihivas sema beallitasa a JWT Bearer sema hasznalatara.
            })
            .AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,              // Ki allitotta ki
                ValidateAudience = true,            // kinél szól
                ValidateLifetime = true,            // Lejart-e
                ValidateIssuerSigningKey = true,    // Alairas ervenyes-e

                ValidIssuer = jwtSettings["Issuer"], // A JWT token ervenyessegenek ellenorzese a megadott issuer ertek alapjan.
                ValidAudience = jwtSettings["Audience"], // A JWT token ervenyessegenek ellenorzese a megadott audience ertek alapjan.
                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtSettings["Key"]!)), // A JWT token alairasanak ervenyessegenek ellenorzese a megadott kulcs alapjan
                ClockSkew = TimeSpan.Zero // Az idoeltolas beallitasa a token ervenyessegnek ellenorzesekor, hogy ne legyen megengedett idoeltoas a token lejarati idejehez kepest.            
            });

            // Egyeb szolgaltatasok regisztralasa, pl.: a JWTTokenService szolgaltatas hozzadadasa a fuggoseginjektorhoz, hogy az alkalmazas hasznalhato legyen a JWT tokenek letrehozasahoz es kezelesehez
            builder.Services.AddScoped<JWTTokenService>();

            builder.Services.AddScoped(typeof(IGenericKoliPortal<>), typeof(GenericKoliPortalService<>));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication(); // Mihez van joga
            app.UseAuthorization(); // Ki a felhasznalo, belephet-e egyaltalan

            app.MapControllers();

            app.Run();
        }
    }
}

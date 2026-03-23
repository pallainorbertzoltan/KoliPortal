using KoliPortal.Lib.SERVICE;
using KoliPortal.Web.Components;

namespace KoliPortal.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri("https://localhost:44331/") });
            builder.Services.AddScoped<DiakAdatokService>();
            builder.Services.AddScoped<SzobakService>();
            builder.Services.AddScoped<KarbantartasiKeresekService>();
            builder.Services.AddScoped<SzobaBeosztasokService>();
            builder.Services.AddScoped<FelhasznalokService>();
            builder.Services.AddScoped<SzerepkorokService>();
            builder.Services.AddScoped<KarbantartasStatuszokService>();
            builder.Services.AddScoped<PenzugyekService>();
            builder.Services.AddScoped<AuthControllerService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}

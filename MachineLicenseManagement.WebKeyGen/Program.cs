using MachineLicenseManagement.WebKeyGen.Components;
using MachineLicenseManagement.WebKeyGen.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace MachineLicenseManagement.WebKeyGen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var constring = "Data Source=PRA1;database=pra_maschlizenz;User ID=mali;Password=Hjert!223h";
            
            builder.Services.AddRazorPages();
            
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                 .AddCookie(options =>
                 {
                     options.LoginPath = "/Login";
                     options.LogoutPath = "/Logout";
                     options.ExpireTimeSpan = TimeSpan.FromDays(30); // Set the expiration time as needed
                     options.SlidingExpiration = true;

                     options.Cookie.SecurePolicy = CookieSecurePolicy.None;
                 });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AuthenticatedUser", policy => policy.RequireAuthenticatedUser());
            });

            builder.Services.AddDbContext<PraMaschlizenzContext>();
            builder.Services.AddScoped<AuthService>();
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseAntiforgery();
            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();
            app.MapRazorPages();
            app.Run();
        }
    }
}

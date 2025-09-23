using MachineLicenseManagement.WebKeyGen;
using Microsoft.AspNetCore.Authentication.JwtBearer;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(LiteDbConfig.CreateDatabase());
builder.Services.AddSingleton<LicenseService>();
builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        //options.Authority = "http://localhost:8080/realms/edge-realm";
        options.Authority = "https://test.connect.dvs-technology.com/edge/auth";
        options.Audience = "edge-frontend-hub";
        options.RequireHttpsMetadata = true;

        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            RoleClaimType = "roles"

        };
        
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                return System.Threading.Tasks.Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                return System.Threading.Tasks.Task.CompletedTask;
            }
        };
    });
builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "LicenseManagement.WebKeyGen API";
    config.Version = "v1";

});

var app = builder.Build();
app.UsePathBase("/webkeygen");
app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseOpenApi();
app.UseSwaggerUi();
app.MapControllers();
app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
//app.MapFallbackToFile("index.html");
app.Run();

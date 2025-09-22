using MachineLicenseManagement.WebKeyGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton(LiteDbConfig.CreateDatabase());
builder.Services.AddSingleton<LicenseService>();
builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddOpenApiDocument(config =>
{
    config.Title = "LicenseManagement.WebKeyGen API";
    config.Version = "v1";

});

var app = builder.Build();
app.UseOpenApi();
app.UseSwaggerUi();
app.MapControllers();
app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
app.Run();

using EncryptionAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Port pour AWS Elastic Beanstalk
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// Lägg till tjänster
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrera krypteringstjänsten
builder.Services.AddScoped<ICryptoService, CaesarCipherService>();

var app = builder.Build();

// Konfigurera Swagger (alltid aktiv)
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Encryption API V1");
    c.RoutePrefix = "swagger";
});

// OMDIRIGERING: "/" går till "/swagger"
app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseAuthorization();
app.MapControllers();
app.Run();
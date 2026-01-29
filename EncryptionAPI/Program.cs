using EncryptionAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Port pour AWS Elastic Beanstalk
builder.WebHost.UseUrls("http://0.0.0.0:5000");

// Lägg till tjänster
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrera krypteringstjänsten
builder.Services.AddScoped<ICryptoService, CaesarCipherService>();

var app = builder.Build();

// Konfigurera Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Encryption API V1");
    c.RoutePrefix = "swagger";
});

// Health check endpoint för AWS
app.MapGet("/", () => "API is running!");

app.UseAuthorization();
app.MapControllers();
app.Run();
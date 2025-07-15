using Microsoft.EntityFrameworkCore;
using ProductService.DataBack;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS para permitir llamadas desde el frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Middleware
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

// Rutas de controladores
app.MapControllers();

app.Run();


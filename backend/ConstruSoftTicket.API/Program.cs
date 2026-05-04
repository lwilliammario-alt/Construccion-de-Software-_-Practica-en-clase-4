// Importa la interfaz del servicio de tickets para registrarla en el contenedor de dependencias
using ConstruSoftTicket.Application.Interfaces;

// Importa la implementación concreta del servicio de tickets
using ConstruSoftTicket.Application.Services;

// Importa el contexto de base de datos de la capa de infraestructura
using ConstruSoftTicket.Infrastructure.Data;

// Importa la implementación concreta del repositorio de tickets
using ConstruSoftTicket.Infrastructure.Repositories;

// Importa Entity Framework Core para configurar el proveedor de base de datos (PostgreSQL)
using Microsoft.EntityFrameworkCore;

// Crea el constructor de la aplicación web, procesando los argumentos de la línea de comandos
var builder = WebApplication.CreateBuilder(args);

// ✅ Configuración de CORS (debe registrarse antes de construir la app)
// Agrega el servicio de CORS al contenedor de inyección de dependencias
builder.Services.AddCors(options =>
{
    // Define una política de CORS llamada "AllowFrontend"
    options.AddPolicy("AllowFrontend",
        policy => policy
            // Permite solicitudes únicamente desde el origen del frontend en desarrollo local
            .WithOrigins("http://localhost:5173") // 👈 Solo tu frontend
            // Permite cualquier método HTTP (GET, POST, PUT, DELETE, etc.)
            .AllowAnyMethod()
            // Permite cualquier encabezado en las solicitudes
            .AllowAnyHeader());
});

// Registra los controladores de la API en el contenedor de servicios
builder.Services.AddControllers();

// Registra el explorador de endpoints necesario para Swagger
builder.Services.AddEndpointsApiExplorer();

// Registra el generador de documentación Swagger para exponer la especificación OpenAPI
builder.Services.AddSwaggerGen();

// Registra el contexto de base de datos con el proveedor de PostgreSQL (Npgsql)
// Obtiene la cadena de conexión "DefaultConnection" desde appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registra la implementación del repositorio de tickets con ciclo de vida Scoped
// (una instancia por solicitud HTTP)
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

// Registra la implementación del servicio de tickets con ciclo de vida Scoped
builder.Services.AddScoped<ITicketService, TicketService>();

// Construye la aplicación web con todos los servicios previamente registrados
var app = builder.Build();

// Habilita el middleware de Swagger para generar el archivo JSON de la especificación OpenAPI
app.UseSwagger();

// Habilita la interfaz gráfica de Swagger UI para explorar y probar los endpoints
app.UseSwaggerUI();

// ✅ El orden de los middlewares es crítico: CORS debe ir antes que Authorization
// Aplica la política de CORS "AllowFrontend" a todas las solicitudes entrantes
app.UseCors("AllowFrontend");

// ⚠️ Redireccionamiento HTTPS comentado para evitar conflictos en desarrollo local
// app.UseHttpsRedirection();

// Habilita el middleware de autorización (verifica tokens, roles, políticas, etc.)
app.UseAuthorization();

// Mapea las rutas de los controladores registrados en el contenedor de servicios
app.MapControllers();

// Inicia la aplicación y comienza a escuchar solicitudes HTTP
app.Run();
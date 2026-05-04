// Importa Entity Framework Core para acceder a las capacidades del ORM
using Microsoft.EntityFrameworkCore;

// Importa la entidad Ticket del dominio para registrarla como tabla en la base de datos
using ConstruSoftTicket.Domain.Entities;

// Define el espacio de nombres de la capa de infraestructura, sección de datos
namespace ConstruSoftTicket.Infrastructure.Data;

// Clase que representa el contexto de la base de datos usando Entity Framework Core
// Hereda de DbContext, que es la clase base del ORM para gestionar la conexión y las entidades
public class AppDbContext : DbContext
{
    // Constructor que recibe las opciones de configuración (como la cadena de conexión)
    // y las pasa a la clase base DbContext
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Propiedad que representa la tabla "Tickets" en la base de datos
    // Usa el método Set<T>() para registrar la entidad Ticket como DbSet
    public DbSet<Ticket> Tickets => Set<Ticket>();
}
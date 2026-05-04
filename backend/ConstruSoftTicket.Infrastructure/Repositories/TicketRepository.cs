// Importa la interfaz del repositorio de tickets que esta clase implementa
using ConstruSoftTicket.Application.Interfaces;

// Importa la entidad Ticket del dominio para manipularla en la base de datos
using ConstruSoftTicket.Domain.Entities;

// Importa el contexto de la base de datos para acceder a las tablas mediante EF Core
using ConstruSoftTicket.Infrastructure.Data;

// Define el espacio de nombres de los repositorios dentro de la capa de infraestructura
namespace ConstruSoftTicket.Infrastructure.Repositories;

// Clase concreta que implementa el acceso a datos para la entidad Ticket
// Implementa el contrato definido en ITicketRepository
public class TicketRepository : ITicketRepository
{
    // Referencia al contexto de base de datos, inyectado mediante el constructor
    private readonly AppDbContext _context;

    // Constructor que recibe el contexto de base de datos por inyección de dependencias
    public TicketRepository(AppDbContext context)
    {
        // Asigna el contexto recibido al campo privado para usarlo en los métodos
        _context = context;
    }

    // Método asíncrono que agrega un ticket a la base de datos y guarda los cambios
    public async Task AddAsync(Ticket ticket)
    {
        // Agrega el ticket al conjunto de tickets en el contexto (pendiente de guardar)
        await _context.Tickets.AddAsync(ticket);

        // Persiste todos los cambios pendientes en la base de datos de forma asíncrona
        await _context.SaveChangesAsync();
    }
}
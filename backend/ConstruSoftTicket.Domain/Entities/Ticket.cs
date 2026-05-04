// Define el espacio de nombres para las entidades del dominio del proyecto
namespace ConstruSoftTicket.Domain.Entities;

// Clase que representa la entidad principal "Ticket" del sistema
public class Ticket
{
    // Identificador único del ticket, generado automáticamente por la base de datos
    public int Id { get; set; }

    // Título corto que describe el problema o solicitud del ticket
    public string Titulo { get; set; } = string.Empty;

    // Descripción detallada del problema o solicitud registrado en el ticket
    public string Descripcion { get; set; } = string.Empty;

    // Fecha y hora de creación del ticket, establecida automáticamente en UTC
    public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
}
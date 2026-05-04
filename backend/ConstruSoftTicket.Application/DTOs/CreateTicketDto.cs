// Define el espacio de nombres para los objetos de transferencia de datos (DTOs) de la capa de aplicación
namespace ConstruSoftTicket.Application.DTOs;

// DTO (Data Transfer Object) que contiene los datos necesarios para crear un nuevo ticket
// Solo expone los campos que el cliente puede enviar, sin incluir Id ni FechaCreacion
public class CreateTicketDto
{
    // Título del ticket enviado por el cliente en la solicitud HTTP
    public string Titulo { get; set; } = string.Empty;

    // Descripción del ticket enviada por el cliente en la solicitud HTTP
    public string Descripcion { get; set; } = string.Empty;
}
// Importa el DTO de creación de ticket para usarlo como parámetro del contrato del servicio
using ConstruSoftTicket.Application.DTOs;

// Define el espacio de nombres de las interfaces de la capa de aplicación
namespace ConstruSoftTicket.Application.Interfaces;

// Interfaz que define el contrato del servicio de tickets
// Permite que el controlador dependa de una abstracción y no de una implementación concreta
public interface ITicketService
{
    // Método asíncrono que crea un nuevo ticket a partir de los datos del DTO
    // Devuelve un mensaje de confirmación como cadena de texto
    Task<string> CreateTicketAsync(CreateTicketDto dto);
}
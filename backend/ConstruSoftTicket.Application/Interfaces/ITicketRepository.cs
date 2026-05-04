// Importa la entidad Ticket del dominio para usarla como parámetro del contrato
using ConstruSoftTicket.Domain.Entities;

// Define el espacio de nombres de las interfaces de la capa de aplicación
namespace ConstruSoftTicket.Application.Interfaces;

// Interfaz que define el contrato que debe cumplir cualquier repositorio de tickets
// Permite desacoplar la lógica de negocio de la implementación concreta de acceso a datos
public interface ITicketRepository
{
    // Método asíncrono que agrega un ticket a la fuente de datos
    // Recibe un objeto Ticket ya construido y devuelve una tarea vacía al completarse
    Task AddAsync(Ticket ticket);
}
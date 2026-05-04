// Importa el DTO necesario para recibir los datos de creación de un ticket
using ConstruSoftTicket.Application.DTOs;

// Importa la interfaz del repositorio y la del servicio para implementarlas
using ConstruSoftTicket.Application.Interfaces;

// Importa la entidad Ticket del dominio para construir el objeto a persistir
using ConstruSoftTicket.Domain.Entities;

// Define el espacio de nombres de los servicios de la capa de aplicación
namespace ConstruSoftTicket.Application.Services;

// Clase que implementa la lógica de negocio para la gestión de tickets
// Implementa el contrato definido en ITicketService
public class TicketService : ITicketService
{
    // Referencia al repositorio de tickets inyectado mediante el constructor
    private readonly ITicketRepository _repository;

    // Constructor que recibe el repositorio por inyección de dependencias
    public TicketService(ITicketRepository repository)
    {
        // Asigna el repositorio recibido al campo privado para usarlo en los métodos
        _repository = repository;
    }

    // Método asíncrono que implementa la creación de un ticket a partir de los datos del DTO
    public async Task<string> CreateTicketAsync(CreateTicketDto dto)
    {
        // Crea un nuevo objeto Ticket mapeando los campos del DTO a la entidad del dominio
        var ticket = new Ticket
        {
            // Asigna el título enviado por el cliente al campo de la entidad
            Titulo = dto.Titulo,

            // Asigna la descripción enviada por el cliente al campo de la entidad
            Descripcion = dto.Descripcion
        };

        // Llama al repositorio para persistir el ticket de forma asíncrona en la base de datos
        await _repository.AddAsync(ticket);

        // Retorna un mensaje de éxito al controlador para informar al cliente
        return "Ticket registrado correctamente.";
    }
}
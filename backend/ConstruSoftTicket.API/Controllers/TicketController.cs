// Importa las clases necesarias para crear controladores en ASP.NET Core
using Microsoft.AspNetCore.Mvc;

// Importa el DTO de creación de ticket para usarlo como parámetro de la acción HTTP
using ConstruSoftTicket.Application.DTOs;

// Importa la interfaz del servicio de tickets para usarla mediante inyección de dependencias
using ConstruSoftTicket.Application.Interfaces;

// Define el espacio de nombres del controlador dentro del proyecto API
namespace ConstruSoftTicket.API.Controllers;

// Marca esta clase como un controlador de API (habilita validación automática de modelos, etc.)
[ApiController]

// Define la ruta base del controlador; "[controller]" se reemplaza automáticamente por "ticket"
[Route("api/[controller]")]
public class TicketController : ControllerBase
{
    // Campo privado que almacena la referencia al servicio de tickets
    private readonly ITicketService _service;

    // Constructor que recibe el servicio de tickets por inyección de dependencias
    public TicketController(ITicketService service)
    {
        // Asigna el servicio recibido al campo privado para usarlo en las acciones
        _service = service;
    }

    // Acción que responde a solicitudes HTTP POST en "api/ticket"
    // Recibe un DTO con los datos del ticket en el cuerpo de la solicitud
    [HttpPost]
    public async Task<IActionResult> Create(CreateTicketDto dto)
    {
        // Llama al servicio para crear el ticket de forma asíncrona y obtiene el mensaje de resultado
        var result = await _service.CreateTicketAsync(dto);

        // Retorna una respuesta HTTP 200 OK con un objeto JSON que contiene el mensaje de éxito
        return Ok(new { mensaje = result });
    }
}

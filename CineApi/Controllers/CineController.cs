using Microsoft.AspNetCore.Mvc;

namespace CineApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CineController : ControllerBase
{
    private readonly ILogger<CineController> _logger;

    public CineController(ILogger<CineController> logger)
    {
        _logger = logger;
    }

    [HttpPost("reservar")]
    public ActionResult<Reserva> ReservarAsientos([FromBody] Reserva reserva)
    {
        // Lógica para reservar asientos
        // Aquí deberías validar los asientos, verificar disponibilidad, etc.
        // Luego guardar la reserva en la base de datos

        return CreatedAtAction(nameof(ReservarAsientos), new { id = reserva.Id }, reserva);
    }

    [HttpPost("ticket")]
    public ActionResult<Ticket> CrearTicket([FromBody] Ticket ticket)
    {
        // Lógica para crear un ticket a partir de una reserva
        // Aquí deberías buscar la reserva y generar el ticket

        return CreatedAtAction(nameof(CrearTicket), new { id = ticket.Id }, ticket);
    }
}
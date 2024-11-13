using Microsoft.AspNetCore.Mvc;
using CineApi; 

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private static List<Reserva> reservas = new List<Reserva>();
        private static List<Ticket> tickets = new List<Ticket>();

        [HttpGet]
        public ActionResult<IEnumerable<Reserva>> GetReservas()
        {
            return Ok(reservas);
        }

        [HttpGet("{id}")]
        public ActionResult<Reserva> GetReserva(int id)
        {
            var reserva = reservas.FirstOrDefault(r => r.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }
            return Ok(reserva);
        }

        [HttpPost]
        public ActionResult<Reserva> CreateReserva(Reserva reserva)
        {
            reserva.Id = reservas.Count + 1; // Asignar un ID simple (en un sistema real, usarías un ID de base de datos)
            reservas.Add(reserva);
            return CreatedAtAction(nameof(GetReserva), new { id = reserva.Id }, reserva);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateReserva(int id, Reserva updatedReserva)
        {
            var reserva = reservas.FirstOrDefault(r => r.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }
            reserva.AsientosReservados = updatedReserva.AsientosReservados;
            reserva.FechaReserva = updatedReserva.FechaReserva;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteReserva(int id)
        {
            var reserva = reservas.FirstOrDefault(r => r.Id == id);
            if (reserva == null)
            {
                return NotFound();
            }
            reservas.Remove(reserva);
            return NoContent();
        }

        [HttpPost("ticket")]
        public ActionResult<Ticket> CreateTicket(Ticket ticket)
        {
            ticket.Id = tickets.Count + 1; // Asignar un ID simple
            tickets.Add(ticket);
            return CreatedAtAction(nameof(CreateTicket), new { id = ticket.Id }, ticket);
        }

        public static void InicializarDatos()
        {
            reservas.Add(new Reserva
            {
                Id = 1,
                FuncionId = 1,
                AsientosReservados = new List<int> { 1, 2 },
                FechaReserva = DateTime.Now
            });
            tickets.Add(new Ticket
            {
                Id = 1,
                ReservaId = 1,
                FechaEmision = DateTime.Now,
               
            });
        }
    }
}
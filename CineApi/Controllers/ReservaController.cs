using Microsoft.AspNetCore.Mvc;
using CineApi; 

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private static List<Reserva> reservas = new List<Reserva>();
        

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
        public ActionResult<Reserva> CreateReserva(Reserva reserva , int SesionId , int PrecioReserva)
        {
            reserva.Id = reservas.Count + 1; // Asignar un ID simple (en un sistema real, usarías un ID de base de datos)
            reserva.IdSesion = SesionId;
           reserva.PrecioReserva = PrecioReserva; 
            reservas.Add(reserva);
            return CreatedAtAction(nameof(GetReserva), new { id = reserva.Id }, reserva);
        }
/*
            [HttpPut("{id}")]
            public IActionResult UpdateReserva(int id, Reserva updatedReserva )
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
            }*/

      /*  public static void InicializarDatos()
        {
            reservas.Add(new Reserva
            {
                Id = 1,
                SesionId = 1,
                AsientosReservados = new List<Asiento> {},
                FechaReserva = DateTime.Now
            });
        }*/
    }
}
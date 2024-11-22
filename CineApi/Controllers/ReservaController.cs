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

        [HttpGet("{idReserva}")]
        public ActionResult<Reserva> GetReserva(int idReserva)
        {
            var reserva = reservas.FirstOrDefault(r => r.IdReserva == idReserva);
            if (reserva == null)
            {
                return NotFound();
            }
            return Ok(reserva);
        }

        [HttpPost]
        public ActionResult<Reserva> CreateReserva(Reserva reserva)
        {
            // Validar que la reserva enviada no sea nula
            if (reserva == null)
            {
                return BadRequest("Los datos de la reserva son inválidos.");
            }

            // Generar un nuevo ID para la reserva
            reserva.IdReserva = reservas.Count + 1;

            // Guardar la reserva en memoria
            reservas.Add(reserva);

            // Retornar la respuesta con el objeto creado y su ubicación
            return CreatedAtAction(nameof(GetReserva), new { idReserva = reserva.IdReserva }, reserva);
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
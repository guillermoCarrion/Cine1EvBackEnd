using Microsoft.AspNetCore.Mvc;
using CineApi; 

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {
        private static List<Sesion> sesiones = new List<Sesion>();
        

        [HttpGet]
        public ActionResult<IEnumerable<Sesion>> GetSesiones()
        {
            return Ok(sesiones);
        }

        [HttpGet("{id}")]
        public ActionResult<Sesion> GetSesion(int id)
        {
            var sesion = sesiones.FirstOrDefault(r => r.Id == id);
            if (sesion == null)
            {
                return NotFound();
            }
            return Ok(sesion);
        }

        [HttpPost]
        public ActionResult<Sesion> CreateSesion(Sesion sesion)
        {
            sesion.Id = sesiones.Count + 1; // Asignar un ID simple (en un sistema real, usarías un ID de base de datos)
            sesiones.Add(sesion);
            return CreatedAtAction(nameof(GetSesion), new { id = sesion.Id }, sesion);
        }


        /*
        [HttpPut("{id}")]
        public IActionResult UpdateSesion(int id, Sesion updatedSesion)
        {
            var sesion = sesiones.FirstOrDefault(r => r.Id == id);
            if (sesion == null)
            {
                return NotFound();
            }
            sesion.AsientosReservados = updatedReserva.AsientosReservados;
            reserva.FechaReserva = updatedReserva.FechaReserva;
            return NoContent();
        }
        */

        /*
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
        */
       

        public void IniciarDatos(){
            sesiones.Add(new Sesion(1, 1, DateTime.Now.AddDays(3), 1, new List<Asiento>asientos){

            })
            int id = 0;
            for(int x = 1; x<=8; x++){
                for(int y = 1; y<=8; y++){
                    id++;
                    Asientos.Add(new Asiento(id:id, fila: y, columna:x) );
                }
        }
    }
        /*
        public static void InicializarDatos()
        {
            reservas.Add(new Reserva
            {
                Id = 1,
                FuncionId = 1,
                AsientosReservados = new List<Asiento> {},
                FechaReserva = DateTime.Now
            });
        }
        */
    }
}
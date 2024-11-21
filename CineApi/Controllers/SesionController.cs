using Microsoft.AspNetCore.Mvc;
using CineApi;

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {
        private static List<Pelicula> peliculas = PeliculaController.Peliculas;
        private static List<Sesion> sesiones = peliculas
                .SelectMany(p => p.sesiones)
                .ToList(); 

        [HttpGet]
        public ActionResult<IEnumerable<Sesion>> GetSesiones()
        {
            return Ok(sesiones);
        }

        [HttpGet("{sesionId}")]
        public ActionResult<Sesion> GetSesion(int sesionId)
        {
            var sesion = sesiones.FirstOrDefault(r => r.IdSesion == sesionId);
            if (sesion == null)
            {
                return NotFound();
            }
            return Ok(sesion);
        }



        // Devuelve las sesiones de una pelicula en concreto
        [HttpGet("{Id}/sesiones")]
        public ActionResult<IEnumerable<Sesion>> GetSesionesDePelicula(int Id)
        {
            var peli = peliculas
                .FirstOrDefault(p => p.Id == Id);


            if (peli == null)
            {
                return NotFound(new { Message = "Sesión no encontrada" });
            }

            return Ok(peli.sesiones);
        }


        // Devuelve los asientos de una sesion
        [HttpGet("{sesionId}/asientos")]
        public ActionResult<IEnumerable<Asiento>> GetAsientosDeSesion(int sesionId)
        {
            var sesion = sesiones
                .FirstOrDefault(s => s.IdSesion == sesionId);

            if (sesion == null)
            {
                return NotFound(new { Message = "Sesión no encontrada" });
            }

            return Ok(sesion.Sala);
        }

        [HttpPost]
        public ActionResult<Sesion> CreateSesion(Sesion sesion)
        {
            sesion.IdSesion = sesiones.Count + 1; // Asignar un ID simple sin base de datos)
            sesiones.Add(sesion);
            return CreatedAtAction(nameof(GetSesion), new { id = sesion.IdSesion }, sesion);
        }


        // Metodo para reservar asientos

        [HttpPost("{sesionId}/asientos/reservar")]
        public ActionResult ReservarAsientos(int sesionId, [FromBody] List<int> asientosIds)
        {
            // Buscar la sesion 
            var sesion = sesiones
                .FirstOrDefault(s => s.IdSesion == sesionId);

            if (sesion == null)
            {
                return NotFound(new { Message = "Sesión no encontrada" });
            }

            // Validar y actualizar los asientos
            var asientosReservados = new List<Asiento>();
            foreach (var idAsiento in asientosIds)
            {
                var asiento = sesion.Sala.FirstOrDefault(a => a.IdAsiento == idAsiento);

                if (asiento == null)
                {
                    return NotFound(new { Message = $"El asiento con ID {idAsiento} no existe en esta sesión." });
                }

                if (asiento.EstaReservado)
                {
                    return BadRequest(new { Message = $"El asiento con ID {idAsiento} ya está reservado." });
                }

                // Reservar el asiento
                asiento.EstaReservado = true;
                asientosReservados.Add(asiento);
            }

            return Ok(new
            {
                Message = "Asientos reservados con éxito",
                AsientosReservados = asientosReservados.Select(a => new
                {
                    a.IdAsiento,
                    a.Precio,
                    a.Fila,
                    a.Columna,
                    a.EstaReservado
                })
            });
        }





        [HttpPut("{id}")]
        public IActionResult UpdateSesion(int id, Sesion updatedSesion)
        {
            var sesion = sesiones.FirstOrDefault(r => r.IdSesion == id);
            if (sesion == null)
            {
                return NotFound();
            }
            sesion = updatedSesion;
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteSesion(int id)
        {
            var sesion = sesiones.FirstOrDefault(r => r.IdSesion == id);
            if (sesion == null)
            {
                return NotFound();
            }
            sesiones.Remove(sesion);
            return NoContent();
        }


    }
}
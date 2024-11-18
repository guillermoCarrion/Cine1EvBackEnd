using Microsoft.AspNetCore.Mvc;
using CineApi;

namespace CineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionController : ControllerBase
    {
        private static List<Sesion> sesiones = new List<Sesion>();
        private static List<Pelicula> peliculas = PeliculaController.Peliculas;

        [HttpGet]
        public ActionResult<IEnumerable<Sesion>> GetSesiones()
        {
            return Ok(sesiones);
        }

        [HttpGet("{id}")]
        public ActionResult<Sesion> GetSesion(int id)
        {
            var sesion = sesiones.FirstOrDefault(r => r.IdSesion == id);
            if (sesion == null)
            {
                return NotFound();
            }
            return Ok(sesion);
        }


        // Devuelve los asientos de una sesion
        [HttpGet("{sesionId}/asientos")]
        public ActionResult<IEnumerable<Asiento>> GetAsientosDeSesion(int sesionId)
        {
            var sesion = peliculas
                .SelectMany(p => p.sesiones)
                .FirstOrDefault(s => s.IdSesion == sesionId);

            if (sesion == null)
            {
                return NotFound(new { Message = "Sesión no encontrada" });
            }

            return Ok(sesion.Sala); 
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

        [HttpPost]
        public ActionResult<Sesion> CreateSesion(Sesion sesion)
        {
            sesion.IdSesion = sesiones.Count + 1; // Asignar un ID simple (en un sistema real, usarías un ID de base de datos)
            sesiones.Add(sesion);
            return CreatedAtAction(nameof(GetSesion), new { id = sesion.IdSesion }, sesion);
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
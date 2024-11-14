

using Microsoft.AspNetCore.Mvc;


namespace CineAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PeliculaController : ControllerBase
{
    private static List<Pelicula> peliculas = new List<Pelicula>();
    
    // Método para inicializar datos



    [HttpGet]
    public ActionResult<IEnumerable<Pelicula>> GetPeliculas()
    {
        return Ok(peliculas);
    }

    [HttpGet("{id}")]
    public ActionResult<Pelicula> GetPelicula(int id)
    {
        var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
        if (pelicula == null)
        {
            return NotFound();
        }
        return Ok(pelicula);
    }

    [HttpPost]
    public ActionResult<Pelicula> CreatePelicula(Pelicula pelicula)
    {
        peliculas.Add(pelicula);
        return CreatedAtAction(nameof(GetPelicula), new { id = pelicula.Id }, pelicula);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePelicula(int id, Pelicula updatedpelicula)
    {
        var pelicula = peliculas.FirstOrDefault(p => p.Id == id);
        if (pelicula == null)
        {
            return NotFound();
        }
        pelicula.Nombre = updatedpelicula.Nombre;
        pelicula.Id = updatedpelicula.Id;
        pelicula.Director = updatedpelicula.Director;
        pelicula.Sinopsis = updatedpelicula.Sinopsis;
        pelicula.Imagen = updatedpelicula.Imagen;


        return NoContent();
    }

    public static void InicializarDatos()
    {
        peliculas.Add(new Pelicula(nombre: "Reservoir Dogs", id: 1, director: "Quentin Tarantino", sinopsis: "Seis criminales profesionales son contratados para robar en un almacén de diamantes, pero la policía aparece inesperadamente en el momento del atraco. Algunos miembros de la banda mueren en el enfrentamiento y otros logran huir.", imagen: "https://i.pinimg.com/736x/6c/0d/da/6c0ddab00848d4ecdf6d5afbf64be0b8.jpg"));
        peliculas.Add(new Pelicula(nombre: "Star Wars", id: 2, director: "George Lucas", sinopsis: "La nave en la que viaja la princesa Leia es capturada por las tropas imperiales al mando del temible Darth Vader. Antes de ser atrapada, Leia consigue introducir un mensaje en su robot R2-D2, quien acompañado de su inseparable C-3PO logran escapar.", imagen: "https://i.pinimg.com/736x/d2/79/3c/d2793c0519e160fa3bd9a223b212f923.jpg"));
        peliculas.Add(new Pelicula(nombre: "Akira", id: 3, director: "Katsuhiro Otomo", sinopsis: "En el Neo-Tokio de 2019, tras la Tercera Guerra Mundial, los viejos amigos Kaneda y Tetsuo son miembros de una violenta banda de motociclistas. Durante una pelea con una banda rival, un extraño niño pequeño con la cara arrugada entra en la refriega.", imagen:"https://i.pinimg.com/736x/b5/e7/e3/b5e7e3aa9a4e0e5ef65e34c7cb9a6e88.jpg"));
        peliculas.Add(new Pelicula(nombre: "2001: A Space Odyssey", id: 4, director: "Stanley Kubrick", sinopsis: "La película de ciencia ficción por antonomasia de la historia del cine narra los diversos periodos de la historia de la humanidad, no sólo del pasado, sino también del futuro.", imagen: "https://i.pinimg.com/736x/8e/2a/e9/8e2ae9256e8bdc4a1265a21cceffb16a.jpg"));
        peliculas.Add(new Pelicula(nombre: "American History X", id: 5, director: "Tony Kaye", sinopsis: "Tras cumplir condena por el asesinato de dos hombres negros, Derek Vinyard, logra vencer su fanatismo, pero no se dará por satisfecho hasta que no haga entrar en razón a su hermano, quien le ve como un héroe e intenta seguir sus pasos.", imagen:"https://i.pinimg.com/736x/1a/5e/d5/1a5ed5133f34b7885c6b2d96c4830f6c.jpg"));
        peliculas.Add(new Pelicula(nombre: "Enter the Void", id: 6, director: "Gaspar Noé", sinopsis: "Óscar (Nathaniel Brown) vive en Tokio con su hermana, Linda (Paz de la Huerta), y se sustenta a sí mismo vendiendo drogas, contra el consejo de su amigo, Alex (Cyril Roy). Alex intenta reubicar el interés de Óscar en el Libro tibetano de los muertos, un libro budista sobre la vida después de la muerte.", imagen:"https://i.pinimg.com/736x/c4/a1/a5/c4a1a516a08e7be519e61a41ff533c46.jpg"));
    }



}

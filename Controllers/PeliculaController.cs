using Microsoft.AspNetCore.Mvc;
namespace CineAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PeliculaController : ControllerBase
{
    public static List<Pelicula> Peliculas = new List<Pelicula>();

    private static int contadorSesionId = 1;
    private static int filas = 6;
    private static int columnas = 8;

    // Método para inicializar datos



    [HttpGet]
    public ActionResult<IEnumerable<Pelicula>> GetPeliculas()
    {
        return Ok(Peliculas);
    }

    [HttpGet("{id}")]
    public ActionResult<Pelicula> GetPelicula(int id)
    {
        var pelicula = Peliculas.FirstOrDefault(p => p.Id == id);
        if (pelicula == null)
        {
            return NotFound();
        }
        return Ok(pelicula);
    }

/*
    [HttpPost]
    public ActionResult<Pelicula> CreatePelicula(Pelicula pelicula)
    {
        Peliculas.Add(pelicula);
        return CreatedAtAction(nameof(GetPelicula), new { id = pelicula.Id }, pelicula);
    }


    [HttpPut("{id}")]
    public IActionResult UpdatePelicula(int id, Pelicula updatedpelicula)
    {
        var pelicula = Peliculas.FirstOrDefault(p => p.Id == id);
        if (pelicula == null)
        {
            return NotFound();
        }
        pelicula.Nombre = updatedpelicula.Nombre;
        pelicula.Id = updatedpelicula.Id;
        pelicula.Director = updatedpelicula.Director;
        pelicula.Sinopsis = updatedpelicula.Sinopsis;
        pelicula.Imagen = updatedpelicula.Imagen;
        pelicula.Duracion = updatedpelicula.Duracion;
        pelicula.Genero = updatedpelicula.Genero;
        pelicula.FechaEstreno = updatedpelicula.FechaEstreno;
        pelicula.Pegi = updatedpelicula.Pegi;


        return NoContent();
    }
*/


    public static void InicializarDatos()
    {
        Peliculas.Add(new Pelicula(nombre: "Reservoir Dogs", id: 1, director: "Quentin Tarantino", sinopsis: "Seis criminales profesionales son contratados para robar en un almacén de diamantes, pero la policía aparece inesperadamente en el momento del atraco. Algunos miembros de la banda mueren en el enfrentamiento y otros logran huir.", imagen: "https://i.pinimg.com/736x/6c/0d/da/6c0ddab00848d4ecdf6d5afbf64be0b8.jpg", idsala : 1 , duracion : "1h 39m" , genero : "Crimen/Suspense" , fechaEstreno : "14 de octubre de 1992." , pegi : "+18" , urlTrailer: "https://www.youtube.com/embed/7GUQGvoDlHw")
        {
            sesiones = GenerarSesiones(1, DateTime.Parse("14:00"), DateTime.Parse("18:00"))
        });

        Peliculas.Add(new Pelicula(nombre: "Star Wars: La amenaza Fantasma", id: 2, director: "George Lucas", sinopsis: "La nave en la que viaja la princesa Leia es capturada por las tropas imperiales al mando del temible Darth Vader. Antes de ser atrapada, Leia consigue introducir un mensaje en su robot R2-D2, quien acompañado de su inseparable C-3PO logran escapar.", imagen: "https://i.pinimg.com/736x/d2/79/3c/d2793c0519e160fa3bd9a223b212f923.jpg", idsala : 2 ,  duracion : " 2h 1m" , genero : " Ciencia Ficción" , fechaEstreno : " 7 de noviembre de 1977." , pegi : " +13" , urlTrailer: "https://www.youtube.com/embed/KHwdeFuKjTU")
        {
            sesiones = GenerarSesiones(2, DateTime.Parse("14:00"), DateTime.Parse("18:00"))
        });

        Peliculas.Add(new Pelicula(nombre: "Akira", id: 3, director: "Katsuhiro Otomo", sinopsis: "En el Neo-Tokio de 2019, tras la Tercera Guerra Mundial, los viejos amigos Kaneda y Tetsuo son miembros de una violenta banda de motociclistas. Durante una pelea con una banda rival, un extraño niño pequeño con la cara arrugada entra en la refriega.", imagen:"https://i.pinimg.com/736x/b5/e7/e3/b5e7e3aa9a4e0e5ef65e34c7cb9a6e88.jpg",idsala : 3,  duracion : " 2h 4m" , genero : " Ciencia Ficción/ Acción" , fechaEstreno : " 16 de julio de 1988." , pegi : " +13" , urlTrailer:"https://www.youtube.com/embed/Y2Ptue29P_o")
        {
            sesiones = GenerarSesiones(3, DateTime.Parse("14:00"), DateTime.Parse("18:00"))
        });

        Peliculas.Add(new Pelicula(nombre: "2001: A Space Odyssey", id: 4, director: "Stanley Kubrick", sinopsis: "La película de ciencia ficción por antonomasia de la historia del cine narra los diversos periodos de la historia de la humanidad, no sólo del pasado, sino también del futuro.", imagen: "https://i.pinimg.com/736x/8e/2a/e9/8e2ae9256e8bdc4a1265a21cceffb16a.jpg",idsala : 4,  duracion : " 2h 29m" , genero : " Ciencia Ficción/ Aventura" , fechaEstreno : " 17 de octubre de 1968." , pegi : " +13", urlTrailer: "https://www.youtube.com/embed/kR2r-A9H3Kg" )
        {
            sesiones = GenerarSesiones(4, DateTime.Parse("14:00"), DateTime.Parse("18:00"))
        });

        Peliculas.Add(new Pelicula(nombre: "American History X", id: 5, director: "Tony Kaye", sinopsis: "Tras cumplir condena por el asesinato de dos hombres negros, Derek Vinyard, logra vencer su fanatismo, pero no se dará por satisfecho hasta que no haga entrar en razón a su hermano, quien le ve como un héroe e intenta seguir sus pasos.", imagen:"https://i.pinimg.com/736x/1a/5e/d5/1a5ed5133f34b7885c6b2d96c4830f6c.jpg",idsala : 5 , duracion : " 1h 59m" , genero : " Crimen" , fechaEstreno : " 19 de marzo de 1999." , pegi : " +17", urlTrailer: "https://www.youtube.com/embed/LZGVcd5clgg")
        {
            sesiones = GenerarSesiones(5, DateTime.Parse("14:00"), DateTime.Parse("18:00"))
        });

        Peliculas.Add(new Pelicula(nombre: "Enter the Void", id: 6, director: "Gaspar Noé", sinopsis: "Óscar (Nathaniel Brown) vive en Tokio con su hermana, Linda (Paz de la Huerta), y se sustenta a sí mismo vendiendo drogas, contra el consejo de su amigo, Alex (Cyril Roy). Alex intenta reubicar el interés de Óscar en el Libro tibetano de los muertos, un libro budista sobre la vida después de la muerte.", imagen:"https://i.pinimg.com/736x/c4/a1/a5/c4a1a516a08e7be519e61a41ff533c46.jpg" ,idsala : 6 , duracion : " 2h 30m" , genero : " Fantasia/ Drama" , fechaEstreno : " 7 de octubre de 2011." , pegi : " +18", urlTrailer: "https://www.youtube.com/embed/JJkPLYmUyzg" )
        {
            sesiones = GenerarSesiones(6, DateTime.Parse("14:00"), DateTime.Parse("18:00"))
        });
    }


    private static List<Sesion> GenerarSesiones(int idsala, DateTime hora1, DateTime hora2)
    {
        var sesiones = new List<Sesion>();

        for (int dia = 1; dia < 4; dia++)
        {
            var fechaBase = DateTime.Today.AddDays(dia);

            // Primera sesión del día
            sesiones.Add(new Sesion
            {
                IdSesion = contadorSesionId++,
                FechaHora = fechaBase.Add(hora1.TimeOfDay),
                IdSala = idsala,
                PeliculaId = idsala,
                Sala = CrearSala()
            });

            // Segunda sesión del día
            sesiones.Add(new Sesion
            {
                IdSesion = contadorSesionId++,
                FechaHora = fechaBase.Add(hora2.TimeOfDay),
                IdSala = idsala,
                Sala = CrearSala()
            });
        }

        return sesiones;
    }


    private static List<Asiento> CrearSala()
    {
        var sala = new List<Asiento>();
        var idasiento = 1;
        for (int fila = 1; fila <= filas; fila++)
        {
            for (int columna = 1; columna <= columnas; columna++)
            {
                sala.Add(new Asiento(idasiento, fila, columna));
                idasiento++;
            }
        }

        return sala;
    }

}

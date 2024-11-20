using Microsoft.AspNetCore.Mvc;
using CineApi;


public class Pelicula
{
    public int Id { get; set; } 
    public string Nombre { get; set; }
    public string Director { get; set; }
    public string Sinopsis { get; set; } 
    public string Imagen { get; set; } 
   public int IdSala {get; set;}

   public string Duracion {get; set;}

   public string Genero {get; set;}

   public string  FechaEstreno {get; set;}

   public string Pegi {get; set;}
    public List<Sesion> sesiones {get; set;} = new List<Sesion>();



 public Pelicula(int id , string nombre, string director, string sinopsis, string imagen, int idsala , string  duracion , string genero , string fechaEstreno, string pegi) {
        Id = id;
        Nombre = nombre;
        Director = director;
         Sinopsis = sinopsis;
         Imagen = imagen;
         IdSala = idsala;
         Duracion = duracion; 
         Genero = genero;
         FechaEstreno = fechaEstreno;
         Pegi = pegi; 
    }

 //Pelicula.InicializarDatos();
}
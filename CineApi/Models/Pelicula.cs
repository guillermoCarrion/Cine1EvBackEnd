using Microsoft.AspNetCore.Mvc;
using CineApi;


public class Pelicula
{
    public int Id { get; set; } 
    public string Nombre { get; set; }
    public string Director { get; set; }
    public string Sinopsis { get; set; } 
    public string Imagen { get; set; } 
    public List<Sesion> sesiones {get; set;} = new List<Sesion>();



 public Pelicula(int id , string nombre, string director, string sinopsis, string imagen) {
        Id = id;
        Nombre = nombre;
        Director = director;
         Sinopsis = sinopsis;
         Imagen = imagen;
    }

 //Pelicula.InicializarDatos();
}
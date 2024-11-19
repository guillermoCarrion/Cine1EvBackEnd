

using Microsoft.AspNetCore.Mvc;
using CineApi;
public class Sesion

{
    public int IdSesion { get; set; }
    public int PeliculaId { get; set; }
    public DateTime FechaHora { get; set; }
    public int IdSala {get; set;}
    public List<Asiento> Sala {get; set;} = new List<Asiento>();

}

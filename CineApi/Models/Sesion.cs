

using Microsoft.AspNetCore.Mvc;
using CineApi;
public class Sesion

{
    public int Id { get; set; }
    public int PeliculaId { get; set; }
    public DateTime FechaHora { get; set; }
    public int IdSala {get; set;}
    public List<Asiento> Asientos {get; set;}


    public Sesion(int id, int peliculaId, DateTime fechaHora, int idSala, List<Asiento> asientos)
    {
        Id = id;
        PeliculaId = peliculaId;
        FechaHora = fechaHora;
        IdSala = idSala;
        Asientos = asientos;
    }
    
}

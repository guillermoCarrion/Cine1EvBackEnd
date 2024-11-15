

using Microsoft.AspNetCore.Mvc;
using CineApi;
public class Sesion

{
    public int Id { get; set; }
    public int PeliculaId { get; set; }
    public DateTime FechaHora { get; set; }
    public int IdSala {get; set;}
    public List<Asiento> Asientos {get; set;}


    public Sesion(int id, int peliculaId, DateTime fechaHora, int idSala)
    {
        Id = id;
        PeliculaId = peliculaId;
        FechaHora = fechaHora;
        IdSala = idSala;

        Asientos = new List<Asiento>();
        for(int x = 1; x<=8; x++){
                    for(int y = 1; y<=8; y++){
                        id++;
                        Asientos.Add(new Asiento(id:id, fila: y, columna:x) );
                }
        }
    }
    
}

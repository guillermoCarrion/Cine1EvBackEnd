

using Microsoft.AspNetCore.Mvc;
using CineApi;
public class Sesion

{
    public int Id { get; set; }
    public int PeliculaId { get; set; }
    public DateTime FechaHora { get; set; }
    public int SalaId { get; set; }
}

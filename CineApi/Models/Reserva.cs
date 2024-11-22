
using Microsoft.AspNetCore.Mvc;
public class Reserva
{
    public int IdReserva { get; set; }
    public int IdPelicula {get; set;}
    public int IdSesion { get; set; }
    public int PrecioReserva { get; set; }
    public List<int> IdAsientosReservados { get; set; } = new List<int>(); // Lista de IDs de asientos reservados
    public DateTime FechaReserva { get; set; }

}


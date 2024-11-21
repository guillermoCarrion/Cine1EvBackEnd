
using Microsoft.AspNetCore.Mvc;
public class Reserva
{
    public int Id { get; set; }
    public int IdSesion { get; set; }
      public int PrecioReserva { get; set; }
    public List<Asiento> AsientosReservados { get; set; } = new List<Asiento>(); // Lista de IDs de asientos reservados
    public DateTime FechaReserva { get; set; }

}


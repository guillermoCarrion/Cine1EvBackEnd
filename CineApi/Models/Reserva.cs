
using Microsoft.AspNetCore.Mvc;
public class Reserva
{
    public int Id { get; set; }
    public int FuncionId { get; set; }
    public List<int> AsientosReservados { get; set; } // Lista de IDs de asientos reservados
    public DateTime FechaReserva { get; set; }

}


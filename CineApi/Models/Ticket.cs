
using Microsoft.AspNetCore.Mvc;
using CineApi;
public class Ticket
{
    public int Id { get; set; }
    public int ReservaId { get; set; }
    public DateTime FechaEmision { get; set; }
  
}

using Microsoft.AspNetCore.Mvc;
using CineApi;
    

public class Asiento
{
    public int Id { get; set; }
    public int Fila { get; set; }
    public int Numero { get; set; }
    public bool EstaReservado { get; set; }
}
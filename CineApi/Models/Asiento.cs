
using Microsoft.AspNetCore.Mvc;
using CineApi;
    

public class Asiento
{
    public int Id { get; set; }
    public int Fila { get; set; }
    public int Columna { get; set; }
    public bool EstaReservado { get; set; } = false;

     public Asiento(int id, int fila, int columna) {
        Id = id;
        Fila = fila;
        Columna = columna;
    }
}

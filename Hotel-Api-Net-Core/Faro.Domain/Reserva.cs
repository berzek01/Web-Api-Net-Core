using System;

namespace Faro.Domain
{
    public class Reserva
    {
        public int Id { get; set; }
        public double Monto { get; set; }
        public string Comentario { get; set; }
        public int CantidadCama { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaRegistro { get; set; }
        public double Descuento { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int HabitacionId { get; set; }
        public Habitacion Habitacion { get; set; }
        public bool Anulado { get; set; }
    }
}
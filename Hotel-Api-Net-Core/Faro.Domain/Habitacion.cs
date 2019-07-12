namespace Faro.Domain
{
    public class Habitacion
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public string Descripcion { get; set; }
        public int TipoHabitacionId { get; set; }
        public TipoHabitacion TipoHabitacion { get; set; }
            
    }
}
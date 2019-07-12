using System.Collections.Generic;

namespace Faro.Domain
{
    public class Pedido
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; }
        public int EmpleadoId { get; set; }
        public Empleado Empleado { get; set; }
        public IEnumerable<DetallePedido> DetallePedido { get; set; }
    }
}
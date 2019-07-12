using System.Collections.Generic;
using Faro.Domain;

namespace Faro.Repository.Dto
{
    public class PedidoDto
    {
        public int Id { get; set; }
        public int ReservaId { get; set; }
        public int EmpleadoId { get; set; }
        public string NombreEmpleado { get; set; }
        public int Total { get; set; }
        public IEnumerable<DetallePedido> DetallePedido { get; set; }
    }
}
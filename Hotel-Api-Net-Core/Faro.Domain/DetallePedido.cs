namespace Faro.Domain
{
    public class DetallePedido
    {
        public int Id { get; set; }
        public double Precio { get; set; }
        public double Descuento { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}
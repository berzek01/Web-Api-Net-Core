using Faro.Domain;
using Microsoft.EntityFrameworkCore;

namespace Faro.Repository.context
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<TipoDocumento> TipoDocumentos { get; set; }
        public DbSet<TipoHabitacion> TipoHabitaciones { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base(options)
        {
            
        }
    }
}
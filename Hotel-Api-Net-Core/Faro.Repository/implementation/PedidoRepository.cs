using System;
using System.Collections.Generic;
using System.Linq;
using Faro.Domain;
using Faro.Repository.context;
using Faro.Repository.Dto;
using Microsoft.EntityFrameworkCore;

namespace Faro.Repository.implementation
{
    public class PedidoRepository : IPedidoRepository
    {
        private ApplicationDbContext context;

        public PedidoRepository (ApplicationDbContext context) {
            this.context = context;
        }
        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Pedido Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Pedido> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PedidoDto> GetAllPedidos()
        {
            var pedido = context.Pedidos
                .Include(o => o.Reserva)
                .Include(o => o.Empleado)
                .OrderByDescending(o => o.Id)
                .Take(10)
                .ToList();

            return pedido.Select (o => new PedidoDto {
                    Id = o.Id,
                    ReservaId = o.ReservaId,
                    EmpleadoId = o.EmpleadoId,
                    NombreEmpleado=o.Empleado.Nombre,
                    Total = o.Total
            });
        }

        public bool Save(Pedido entity)
        {
            try {
                //Objecto Order
                Pedido pedido = new Pedido {
                    ReservaId = entity.ReservaId,
                    EmpleadoId = entity.EmpleadoId,
                    Total = entity.Total
                };
                context.Pedidos.Add(pedido);
                context.SaveChanges();
                var pedidoId = pedido.Id;

                //Objeto DetalleOrden
                foreach (var item in entity.DetallePedido) {
                    DetallePedido detalle = new DetallePedido {
                        PedidoId = item.PedidoId,
                        ProductoId = item.ProductoId,
                        Cantidad = item.Cantidad,
                        Descuento = item.Descuento,
                        Precio = item.Precio
                    };
                    context.DetallePedidos.Add(detalle);
                }

                context.SaveChanges();

            } catch (Exception ex) {
                return false;
            }
            return true;
        }

        public bool Update(Pedido entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
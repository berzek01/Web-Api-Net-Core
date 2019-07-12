using System.Collections.Generic;
using System.Linq;
using Faro.Domain;
using Faro.Repository.context;
using Microsoft.EntityFrameworkCore;

namespace Faro.Repository.implementation
{
    public class ReservaRepository : IReservaRepository
    {
        private ApplicationDbContext context;
        public ReservaRepository(ApplicationDbContext context)
        {
            this.context=context;
        }
        public bool Delete(int id)
        {
            try
            {
                var result = context.Reservas.Single(x => x.Id == id);
                result.Anulado=true;
                context.Update(result);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Reserva Get(int id)
        {
            var result = new Reserva();
            try
            {
                result = context.Reservas.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Reserva> GetAll()
        {
            var result = new List<Reserva>();
            try
            {
                result = context.Reservas.Include(c => c.Empleado).ToList();
                result = context.Reservas.Include(c => c.Cliente).ToList();
                result = context.Reservas.Include(c => c.Habitacion).ToList();

                result.Select(c => new Reserva
                {
                    Id= c.Id,
                    Monto =c.Monto,
                    Comentario=c.Comentario,
                    CantidadCama=c.CantidadCama,
                    FechaInicio=c.FechaInicio,
                    FechaFin=c.FechaFin,
                    FechaRegistro=c.FechaRegistro,
                    Descuento=c.Descuento,
                    EmpleadoId=c.EmpleadoId,
                    ClienteId=c.ClienteId,
                    HabitacionId=c.HabitacionId,
                    Anulado=c.Anulado
                }).Where(c => c.Anulado==false); 
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public bool Save(Reserva entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public bool Update(Reserva entity)
        {
            try
            {
                 var reservaOrigina = context.Reservas.Single(
                     x => x.Id == entity.Id
                 );

                 reservaOrigina.Id=entity.Id;
                 reservaOrigina.Monto =entity.Monto;
                 reservaOrigina.Comentario=entity.Comentario;
                 reservaOrigina.CantidadCama=entity.CantidadCama;
                 reservaOrigina.FechaInicio=entity.FechaInicio;
                 reservaOrigina.FechaFin=entity.FechaFin;
                 reservaOrigina.FechaRegistro=entity.FechaRegistro;
                 reservaOrigina.Descuento=entity.Descuento;
                 reservaOrigina.EmpleadoId=entity.EmpleadoId;
                 reservaOrigina.ClienteId=entity.ClienteId;
                 reservaOrigina.HabitacionId=entity.HabitacionId;
                 reservaOrigina.Anulado=entity.Anulado;
                
                 context.Update(reservaOrigina);
                 context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }
    }
}
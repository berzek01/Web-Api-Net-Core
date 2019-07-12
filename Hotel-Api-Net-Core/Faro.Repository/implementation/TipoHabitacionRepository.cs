using System.Collections.Generic;
using System.Linq;
using Faro.Domain;
using Faro.Repository.context;

namespace Faro.Repository.implementation
{
    public class TipoHabitacionRepository : ITipoHabitacionRepository
    {
        private ApplicationDbContext context;
        public TipoHabitacionRepository(ApplicationDbContext context)
        {
            this.context=context;
        }
        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public TipoHabitacion Get(int id)
        {
            var result = new TipoHabitacion();
            try
            {
                result = context.TipoHabitaciones.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<TipoHabitacion> GetAll()
        {
            var result = new List<TipoHabitacion>();
            try
            {
                result.Select(c => new TipoHabitacion
                {
                    Id= c.Id,
                    Tipo=c.Tipo,
                    Precio=c.Precio,
                    CantidadMaximaCama=c.CantidadMaximaCama
                }); 
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public bool Save(TipoHabitacion entity)
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

        public bool Update(TipoHabitacion entity)
        {
            try
            {
                 var tipoHabitacionOrigina = context.TipoHabitaciones.Single(
                     x => x.Id == entity.Id
                 );

                 tipoHabitacionOrigina.Id=entity.Id;
                 tipoHabitacionOrigina.Tipo =entity.Tipo;
                 tipoHabitacionOrigina.Precio=entity.Precio;
                 tipoHabitacionOrigina.CantidadMaximaCama=entity.CantidadMaximaCama;
                
                 context.Update(tipoHabitacionOrigina);
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
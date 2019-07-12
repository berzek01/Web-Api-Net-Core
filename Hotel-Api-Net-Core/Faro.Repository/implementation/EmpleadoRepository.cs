using System.Collections.Generic;
using System.Linq;
using Faro.Domain;
using Faro.Repository.context;
using Microsoft.EntityFrameworkCore;

namespace Faro.Repository.implementation
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private ApplicationDbContext context;
        public EmpleadoRepository(ApplicationDbContext context)
        {
            this.context=context;
        }
        public bool Delete(int id)
        {
            try
            {
                var result = context.Empleados.Single(x => x.Id == id);
                result.Eliminado=true;
                context.Update(result);
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Empleado Get(int id)
        {
            var result = new Empleado();
            try
            {
                result = context.Empleados.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Empleado> GetAll()
        {
            var result = new List<Empleado>();
            try
            {
                result = context.Empleados.Include(c => c.TipoDocumento).ToList();

                result.Select(c => new Empleado
                {
                    Id= c.Id,
                    Nombre =c.Nombre,
                    ApellidoPaterno=c.ApellidoPaterno,
                    ApellidoMaterno=c.ApellidoMaterno,
                    FechaNacimiento=c.FechaNacimiento,
                    FechaRegistro=c.FechaRegistro,
                    Pais=c.Pais,
                    NumeroDocumento=c.NumeroDocumento,
                    TipoDocumentoId=c.TipoDocumentoId,
                    Eliminado=c.Eliminado
                }).Where(c => c.Eliminado==false); 
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public bool Save(Empleado entity)
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

        public bool Update(Empleado entity)
        {
            try
            {
                 var empleadoOrigina = context.Empleados.Single(
                     x => x.Id == entity.Id
                 );

                 empleadoOrigina.Id=entity.Id;
                 empleadoOrigina.Nombre =entity.Nombre;
                 empleadoOrigina.ApellidoPaterno=entity.ApellidoPaterno;
                 empleadoOrigina.ApellidoMaterno=entity.ApellidoMaterno;
                 empleadoOrigina.FechaNacimiento=entity.FechaNacimiento;
                 empleadoOrigina.FechaRegistro=entity.FechaRegistro;
                 empleadoOrigina.Pais=entity.Pais;
                 empleadoOrigina.NumeroDocumento=entity.NumeroDocumento;
                 empleadoOrigina.TipoDocumentoId=entity.TipoDocumentoId;
                 empleadoOrigina.Eliminado=entity.Eliminado;
                
                 context.Update(empleadoOrigina);
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
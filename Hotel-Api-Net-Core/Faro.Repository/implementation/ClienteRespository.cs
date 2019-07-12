using System.Collections.Generic;
using System.Linq;
using Faro.Domain;
using Faro.Repository.context;
using Microsoft.EntityFrameworkCore;

namespace Faro.Repository.implementation
{
    public class ClienteRespository : IClienteRepository
    {
        private ApplicationDbContext context;
        public ClienteRespository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool Delete(int id)
        {
            try
            {
                var result = context.Clientes.Single(x => x.Id == id);
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

        public Cliente Get(int id)
        {
            var result = new Cliente();
            try
            {
                result = context.Clientes.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Cliente> GetAll()
        {
            var result = new List<Cliente>();
            try
            {
                result = context.Clientes.Include(c => c.TipoDocumento).ToList();

                result.Select(c => new Cliente
                {
                    Id= c.Id,
                    Nombre =c.Nombre,
                    ApellidoPaterno=c.ApellidoPaterno,
                    ApellidoMaterno=c.ApellidoMaterno,
                    Telefono=c.Telefono,
                    FechaNacimiento=c.FechaNacimiento,
                    FechaRegistro=c.FechaRegistro,
                    Pais=c.Pais,
                    NumeroDocumento=c.NumeroDocumento,
                    TipoDocumentoId=c.TipoDocumentoId,
                    Vip=c.Vip,
                    Eliminado=c.Eliminado
                }).Where(c=>c.Eliminado==false); 
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public bool Save(Cliente entity)
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

        public bool Update(Cliente entity)
        {
            try
            {
                 var clienteOrigina = context.Clientes.Single(
                     x => x.Id == entity.Id
                 );

                 clienteOrigina.Id=entity.Id;
                 clienteOrigina.Nombre =entity.Nombre;
                 clienteOrigina.ApellidoPaterno=entity.ApellidoPaterno;
                 clienteOrigina.ApellidoMaterno=entity.ApellidoMaterno;
                 clienteOrigina.Telefono=entity.Telefono;
                 clienteOrigina.FechaNacimiento=entity.FechaNacimiento;
                 clienteOrigina.FechaRegistro=entity.FechaRegistro;
                 clienteOrigina.Pais=entity.Pais;
                 clienteOrigina.NumeroDocumento=entity.NumeroDocumento;
                 clienteOrigina.TipoDocumentoId=entity.TipoDocumentoId;
                 clienteOrigina.Vip=entity.Vip;
                 clienteOrigina.Eliminado=entity.Eliminado;
                
                 context.Update(clienteOrigina);
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
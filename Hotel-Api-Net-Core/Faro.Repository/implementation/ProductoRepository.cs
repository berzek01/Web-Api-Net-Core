using System.Collections.Generic;
using System.Linq;
using Faro.Domain;
using Faro.Repository.context;
using Microsoft.EntityFrameworkCore;

namespace Faro.Repository.implementation
{
    public class ProductoRepository : IProductoRepository
    {
        private ApplicationDbContext context;
        public ProductoRepository(ApplicationDbContext context)
        {
            this.context=context;
        }
        public bool Delete(int id)
        {
            try
            {
                context.Remove(context.Productos.Single(a => a.Id == id));
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Producto Get(int id)
        {
            var result = new Producto();
            try
            {
                result = context.Productos.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Producto> GetAll()
        {
            var result = new List<Producto>();
            try
            {
                result = context.Productos.Include(c => c.Categoria).ToList();

                result.Select(c => new Producto
                {
                    Id= c.Id,
                    Nombre =c.Nombre,
                    Descripcion=c.Descripcion,
                    Precio=c.Precio,
                    CategoriaId=c.CategoriaId
                }); 
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public bool Save(Producto entity)
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

        public bool Update(Producto entity)
        {
            try
            {
                var productoOrigina = context.Productos.Single(
                    x => x.Id == entity.Id
                );

                productoOrigina.Id=entity.Id;
                productoOrigina.Nombre =entity.Nombre;
                productoOrigina.Descripcion=entity.Descripcion;
                productoOrigina.Precio=entity.Precio;
                productoOrigina.CategoriaId=entity.CategoriaId;
                
                context.Update(productoOrigina);
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
using System.Collections.Generic;
using System.Linq;
using Faro.Domain;
using Faro.Repository.context;

namespace Faro.Repository.implementation
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private ApplicationDbContext context;
        public CategoriaRepository(ApplicationDbContext context)
        {
            this.context=context;
        }
        public bool Delete(int id)
        {
            try
            {
                context.Remove(context.Categorias.Single(a => a.Id == id));
                context.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public Categoria Get(int id)
        {
            var result = new Categoria();
            try
            {
                result = context.Categorias.Single(x => x.Id == id);
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public IEnumerable<Categoria> GetAll()
        {
            var result = new List<Categoria>();
            try
            {
                result.Select(c => new Categoria
                {
                    Id= c.Id,
                    Nombre =c.Nombre
                }); 
            }
            catch (System.Exception)
            {
                throw;
            }
            return result;
        }

        public bool Save(Categoria entity)
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

        public bool Update(Categoria entity)
        {
            try
            {
                var categoriaOrigina = context.Categorias.Single(
                    x => x.Id == entity.Id
                );

                categoriaOrigina.Id=entity.Id;
                categoriaOrigina.Nombre =entity.Nombre;
                
                context.Update(categoriaOrigina);
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
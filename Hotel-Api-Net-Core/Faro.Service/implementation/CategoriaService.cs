using System.Collections.Generic;
using Faro.Domain;
using Faro.Repository;

namespace Faro.Service.implementation
{

    public class CategoriaService : ICategoriaService
    {
        private ICategoriaRepository categoriaRepository;
        
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            this.categoriaRepository=categoriaRepository;
        }
        public bool Delete(int id)
        {
            return categoriaRepository.Delete(id);
        }

        public Categoria Get(int id)
        {
            return categoriaRepository.Get(id);
        }

        public IEnumerable<Categoria> GetAll()
        {
            return categoriaRepository.GetAll();
        }

        public bool Save(Categoria entity)
        {
            return categoriaRepository.Save(entity);
        }

        public bool Update(Categoria entity)
        {
            return categoriaRepository.Update(entity);
        }
    }
}
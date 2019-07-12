using System.Collections.Generic;
using Faro.Domain;
using Faro.Repository;

namespace Faro.Service.implementation
{
    public class ProductoService : IProductoService
    {
        private IProductoRepository productoRepository;
        
        public ProductoService(IProductoRepository productoRepository)
        {
            this.productoRepository=productoRepository;
        }
        public bool Delete(int id)
        {
            return productoRepository.Delete(id);
        }

        public Producto Get(int id)
        {
            return productoRepository.Get(id);
        }

        public IEnumerable<Producto> GetAll()
        {
            return productoRepository.GetAll();
        }

        public bool Save(Producto entity)
        {
            return productoRepository.Save(entity);
        }

        public bool Update(Producto entity)
        {
            return productoRepository.Update(entity);
        }
    }
}
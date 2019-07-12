using System.Collections.Generic;
using Faro.Domain;
using Faro.Repository;
using Faro.Repository.Dto;

namespace Faro.Service.implementation
{
    public class PedidoService : IPedidoService
    {
        private IPedidoRepository pedidoRepository;

        public PedidoService (IPedidoRepository pedidoRepository) {
            this.pedidoRepository = pedidoRepository;
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
            return pedidoRepository.GetAllPedidos();
        }

        public bool Save(Pedido entity)
        {
            return pedidoRepository.Save(entity);
        }

        public bool Update(Pedido entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
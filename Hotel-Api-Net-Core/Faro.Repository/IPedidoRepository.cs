using System.Collections.Generic;
using Faro.Domain;
using Faro.Repository.Dto;

namespace Faro.Repository
{
    public interface IPedidoRepository:IRepository<Pedido>
    {
         IEnumerable<PedidoDto> GetAllPedidos ();
    }
}
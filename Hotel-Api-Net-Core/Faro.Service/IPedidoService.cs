using System.Collections.Generic;
using Faro.Domain;
using Faro.Repository.Dto;

namespace Faro.Service
{
    public interface IPedidoService:IService<Pedido>
    {
         IEnumerable<PedidoDto> GetAllPedidos();
    }
}
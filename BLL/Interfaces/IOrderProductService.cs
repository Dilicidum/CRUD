using BLL.ModelsDTO.DTO;
using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces{
    public interface IOrderProductService 
    {
        Task<IEnumerable<OrderProductDTO>> GetOrderProduct();
        OrderProduct UpdateOrderProduct(OrderProductDTO orderProduct);
    }
}
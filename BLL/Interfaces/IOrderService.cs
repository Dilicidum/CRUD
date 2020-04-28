using System.Threading.Tasks;
using System.Collections.Generic;
using BLL.ModelsDTO.DTO;
using BLL.ModelsDTO.Resources;
using DAL.Entities;

namespace BLL.Interfaces{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAllOrders();
        Task<OrderDTO> GetOrderById(int id);

        Task<Order> GetById(int id);
        Task<IEnumerable<OrderProduct>> AddOrder(OrderResource orderResource);
        Task<int> FindOrderId(OrderResource orderResource);
        Task DeleteOrderById(int id);
        Task DeleteAllOrders();
        Task<OrderProduct> UpdateOrder(int productId, int orderId);
    }
}
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IOrderProductRepository:IRepository<OrderProduct>
    {
        public Task<IEnumerable<OrderProduct>> GetAllWithOrderAndProductAsync();
        public Task<OrderProduct> GetWithOrderAndProductByOrderId(int id);
        void UpdateOrderProduct(OrderProduct orderProduct);
    }
}
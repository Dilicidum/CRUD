using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IOrderRepository:IRepository<Order>
    {
        public Task<IEnumerable<Order>> GetAllWithProducts();
        public Task<Order> GetWithProductsById(int id);
    }
}

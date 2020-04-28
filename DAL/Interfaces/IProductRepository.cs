using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
namespace DAL.Interfaces
{
    public interface IProductRepository:IRepository<Product>
    {
        public Task<IEnumerable<Product>> GetAllWithOrders();
        public Task<Product> GetWithOrderById(int id);
    }
}

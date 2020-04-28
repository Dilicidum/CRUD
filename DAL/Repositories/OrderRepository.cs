using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace DAL.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context) { }
        private ApplicationDbContext context
        {
            get { return Context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<Order>> GetAllWithProducts()
        {
            return await context.Orders
                .Include(c => c.OrderProducts)
                .ThenInclude(c => c.Product)
                .ToListAsync();
        }

        public async Task<Order> GetWithProductsById(int id)
        {
            return await context.Orders
                .Include(c => c.OrderProducts)
                .ThenInclude(c=>c.Product)
                .SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
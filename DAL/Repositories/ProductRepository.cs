using DAL;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductRepository:Repository<Product>,IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) :base(context){ }

        private ApplicationDbContext context
        {
            get { return Context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<Product>> GetAllWithOrders()
        {
            return await context.Products
                .Include(a => a.OrderProducts)
                .ToListAsync();
        }

        public async Task<Product> GetWithOrderById(int id)
        {
            return await context.Products
                .Include(a => a.OrderProducts)
                .SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}
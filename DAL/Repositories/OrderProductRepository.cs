using DAL;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class OrderProductRepository:Repository<OrderProduct>,IOrderProductRepository
    {
        public OrderProductRepository(ApplicationDbContext context) : base(context) { }
        private ApplicationDbContext context
        {
            get { return Context as ApplicationDbContext; }
        }

        public async Task<IEnumerable<OrderProduct>> GetAllWithOrderAndProductAsync()
        {
            return await context.OrderProducts
                .Include(c => c.Product)
                .Include(c => c.Order)
                .ToListAsync();
        }

        public async Task<OrderProduct> GetWithOrderAndProductByOrderId(int id)
        {
            return await context.OrderProducts
                .Include(c => c.Order)
                .Include(c => c.Product)
                .SingleOrDefaultAsync(c => c.OrderId == id);
        }

        public void UpdateOrderProduct(OrderProduct orderProduct)
        {
            var result = context.OrderProducts.Where(c => c.OrderId == orderProduct.OrderId && c.ProductId == orderProduct.ProductId).FirstOrDefault();
            //context.Entry(orderProduct).State = EntityState.Modified;
            
            result.Product = orderProduct.Product;
            result.Order = orderProduct.Order;
            context.SaveChanges();
        }
    }
}

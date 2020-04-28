using System;
using System.Collections.Generic;
using System.Text;
using DAL.Interfaces;
using DAL.Entities;
using DAL.Repositories;
using DAL;
using System.Threading.Tasks;
namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        private OrderRepository orderRepository;
        private ProductRepository productRepository;
        private OrderProductRepository orderProductRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IProductRepository ProductRepository => productRepository = productRepository ?? new ProductRepository(context);

        public IOrderRepository OrderRepository => orderRepository = orderRepository ?? new OrderRepository(context);
        public IOrderProductRepository OrderProductRepository => orderProductRepository = orderProductRepository ?? new OrderProductRepository(context);

        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}

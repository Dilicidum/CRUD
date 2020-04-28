using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository OrderRepository { get; }
        IProductRepository ProductRepository { get; }
        IOrderProductRepository OrderProductRepository { get; }
        Task<int> Save();
    }
}

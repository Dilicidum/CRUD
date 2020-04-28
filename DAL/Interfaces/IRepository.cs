using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<Tentity> where Tentity : class
    {
        Task<Tentity> GetByIdAsync(int id);
        Task<IEnumerable<Tentity>> GetAllAsync();
        Task AddAsync(Tentity entity);
        Task AddRangeAsync(IEnumerable<Tentity> entity);
        void Remove(Tentity entity);
        void RemoveRange(IEnumerable<Tentity> entities);

        void Update(Tentity entityToUpdate);
    }
}

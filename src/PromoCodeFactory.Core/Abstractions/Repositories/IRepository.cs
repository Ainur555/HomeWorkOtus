using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Domain;

namespace PromoCodeFactory.Core.Abstractions.Repositories
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default, bool asNoTracking = false);
        IQueryable<T> GetAll(bool noTracking = false);
        Task<T> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);

        bool DeleteAsync(Guid id);

        void Update(T entity);

        Task AddRangeAsync(ICollection<T> entities);

        Task SaveChangesAsync(CancellationToken cancellationToken = default);

        void SaveChanges();
    }
}
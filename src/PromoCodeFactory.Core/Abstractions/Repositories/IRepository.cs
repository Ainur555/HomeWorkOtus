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
        Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken, string includes = null);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);

        bool Delete(Guid id);

        void Update(T entity);

        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
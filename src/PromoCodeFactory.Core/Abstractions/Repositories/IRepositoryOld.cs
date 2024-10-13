using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Domain;

namespace PromoCodeFactory.Core.Abstractions.Repositories
{
    public interface IRepositoryOld<T> where T : BaseEntity
    {      
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(T entity);
    }
}

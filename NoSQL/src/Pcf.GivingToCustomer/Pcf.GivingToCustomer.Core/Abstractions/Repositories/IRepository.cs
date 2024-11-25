using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Pcf.GivingToCustomer.Core.Domain;

namespace Pcf.GivingToCustomer.Core.Abstractions.Repositories
{
    public interface IRepository<T>
        where T: BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
        
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        
        Task<IEnumerable<T>> GetRangeByIdsAsync(List<Guid> ids, CancellationToken cancellationToken);
        
        Task<T> GetFirstWhere(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        
        Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);

        Task AddAsync(T entity, CancellationToken cancellationToken);

        Task UpdateAsync(Guid id, T entity, CancellationToken cancellationToken);

        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}
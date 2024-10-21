using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.DataAccess.Contracts.Employee;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список сотрудников </returns>
        Task<List<Employee>> GetPagedAsync(EmployeeFilterDto filterDto, CancellationToken cancellationToken);
    }
}

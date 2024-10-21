using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameWorkCore;
using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.DataAccess.Contracts.Employee;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public class EmployeeRepository(EfDbContext context) : EfRepository<Employee>(context), IEmployeeRepository
    {
        public Task<List<Employee>> GetPagedAsync(EmployeeFilterDto filterDto, CancellationToken cancellationToken)
        {
            var query = GetAll();

            query = query.Where(c => c.FirstName == filterDto.FirstName);

            query = query.Where(c => c.Email == filterDto.Email);

            query = query.Where(c => c.LastName == filterDto.LastName);

            query = query
                .Skip((filterDto.Page - 1) * filterDto.ItemsPerPage)
                .Take(filterDto.ItemsPerPage);

            return query.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
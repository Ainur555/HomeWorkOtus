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

            if (!string.IsNullOrEmpty(filterDto.FirstName))
            {
                query = query.Where(c => c.FirstName == filterDto.FirstName);
            }

            if (!string.IsNullOrEmpty(filterDto.LastName))
            {
                query = query.Where(c => c.LastName == filterDto.LastName);
            }

            if (!string.IsNullOrEmpty(filterDto.Email))
            {
                query = query.Where(c => c.Email == filterDto.Email);
            }

            query = query
                .Skip((filterDto.Page - 1) * filterDto.ItemsPerPage)
                .Take(filterDto.ItemsPerPage);

            return query.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
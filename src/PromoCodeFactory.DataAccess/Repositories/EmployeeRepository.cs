using EntityFrameWorkCore;
using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.DataAccess.Contracts.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public class EmployeeRepository : EfRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(EfDbContext context) : base(context)
        {
        }
     
        public async Task<List<Employee>> GetPagedAsync(EmployeeFilterDto filterDto)
        {
            var query = GetAll();

            if (!string.IsNullOrWhiteSpace(filterDto.FirstName))
            {
                query = query.Where(c => c.FirstName == filterDto.FirstName);
            }

            if (!string.IsNullOrWhiteSpace(filterDto.Email))
            {
                query = query.Where(c => c.Email == filterDto.Email);
            }

            if (!string.IsNullOrWhiteSpace(filterDto.LastName))
            {
                query = query.Where(c => c.LastName == filterDto.LastName);
            }

            query = query
                .Skip((filterDto.Page - 1) * filterDto.ItemsPerPage)
                .Take(filterDto.ItemsPerPage);

            return await query.ToListAsync();
        }
    }
}

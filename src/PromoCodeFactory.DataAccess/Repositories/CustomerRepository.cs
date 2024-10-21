using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameWorkCore;
using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(EfDbContext context) : base(context)
        {
        }

        public Task<List<Customer>> GetPagedAsync(CustomerFilterDto filterDto, CancellationToken cancellationToken)
        {
            var query = GetAll()
                .Include(c => c.Preferences)
                .Include(c => c.PromoCodes).AsQueryable();

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
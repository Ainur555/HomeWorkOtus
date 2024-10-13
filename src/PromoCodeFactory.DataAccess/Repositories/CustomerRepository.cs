using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.Core.Domain.Administration;
using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.DataAccess.Contracts;
using EntityFrameWorkCore;


namespace PromoCodeFactory.DataAccess.Repositories
{
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(EfDbContext context) : base(context)
        {
        }       

        public async Task<List<Customer>> GetPagedAsync(CustomerFilterDto filterDto)
        {
            var query = GetAll()
            .Include(c => c.Preferences)
            .Include(c => c.PromoCodes).AsQueryable();

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

using EntityFrameWorkCore;
using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public class CustomerPreferenceRepository : ICustomerPreferenceRepository
    {
        private readonly EfDbContext _context;

        public CustomerPreferenceRepository(EfDbContext context)
        {
            _context = context;
        }

        public async Task AddPreferenceToCustomerAsync(CustomerPreference customerPreference)
        {
            var exists = await _context.CustomerPreferences
                .AnyAsync(cp => cp.CustomerId == customerPreference.CustomerId && cp.PreferenceId == customerPreference.PreferenceId);

            if (!exists)
            {
                _context.CustomerPreferences.Add(customerPreference);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"У этого клиента {customerPreference.CustomerId} уже есть это предпочтение {customerPreference.PreferenceId}");
            }

        }

        public async Task<List<Customer>> GetCustomersByPreferenceAsync(Guid preferenceId)
        {
            return await _context.CustomerPreferences
             .Where(cp => cp.PreferenceId == preferenceId)
             .Select(cp => cp.Customer)
             .ToListAsync();
        }

        public async Task<List<Preference>> GetPreferencesByCustomerAsync(Guid customerId)
        {
            return await _context.CustomerPreferences
              .Where(cp => cp.CustomerId == customerId)
              .Select(cp => cp.Preference)
              .ToListAsync();
        }

        public async Task<CustomerPreference> GetCustomerPreference(Guid customerId, Guid preferenceId)
        {
            return await _context.CustomerPreferences
            .FirstOrDefaultAsync(cp => cp.CustomerId == customerId && cp.PreferenceId == preferenceId);
        }



        public async Task RemovePreferenceFromCustomerAsync(Guid customerId, Guid preferenceId)
        {
            var customerPreference = await _context.CustomerPreferences
             .FirstOrDefaultAsync(cp => cp.CustomerId == customerId && cp.PreferenceId == preferenceId);

            if (customerPreference != null)
            {
                _context.CustomerPreferences.Remove(customerPreference);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameWorkCore;
using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public class CustomerPreferenceRepository : ICustomerPreferenceRepository
    {
        private readonly EfDbContext _context;

        public CustomerPreferenceRepository(EfDbContext context)
        {
            _context = context;
        }

        public async Task AddPreferenceToCustomerAsync(CustomerPreference customerPreference, CancellationToken cancellationToken)
        {
            var exists = await _context.CustomerPreferences
                .AnyAsync(cp => cp.CustomerId == customerPreference.CustomerId && cp.PreferenceId == customerPreference.PreferenceId, cancellationToken: cancellationToken);

            if (!exists)
            {
                _context.CustomerPreferences.Add(customerPreference);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new Exception($"У этого клиента {customerPreference.CustomerId} уже есть это предпочтение {customerPreference.PreferenceId}");
            }

        }

        public Task<List<Customer>> GetCustomersByPreferenceAsync(Guid preferenceId, CancellationToken cancellationToken)
        {
            return _context.CustomerPreferences
                .Where(cp => cp.PreferenceId == preferenceId)
                .Select(cp => cp.Customer)
                .ToListAsync(cancellationToken);
        }

        public Task<List<Preference>> GetPreferencesByCustomerAsync(Guid customerId, CancellationToken cancellationToken)
        {
            return _context.CustomerPreferences
                .Where(cp => cp.CustomerId == customerId)
                .Select(cp => cp.Preference)
                .ToListAsync(cancellationToken);
        }

        public Task<CustomerPreference> GetCustomerPreference(Guid customerId, Guid preferenceId)
        {
            return _context.CustomerPreferences
                .FirstOrDefaultAsync(cp => cp.CustomerId == customerId && cp.PreferenceId == preferenceId);
        }



        public async Task RemovePreferenceFromCustomerAsync(Guid customerId, Guid preferenceId, CancellationToken cancellationToken)
        {
            var customerPreference = await _context.CustomerPreferences
             .FirstOrDefaultAsync(cp => cp.CustomerId == customerId && cp.PreferenceId == preferenceId, cancellationToken);

            if (customerPreference != null)
            {
                _context.CustomerPreferences.Remove(customerPreference);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}

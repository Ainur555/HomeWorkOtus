using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public interface ICustomerPreferenceRepository
    {
        Task AddPreferenceToCustomerAsync(CustomerPreference customerPreference, CancellationToken cancellationToken);
        Task RemovePreferenceFromCustomerAsync(Guid customerId, Guid preferenceId, CancellationToken cancellationToken);
        Task<List<Preference>> GetPreferencesByCustomerAsync(Guid customerId, CancellationToken cancellationToken);
        Task<List<Customer>> GetCustomersByPreferenceAsync(Guid preferenceId, CancellationToken cancellationToken);

        Task<CustomerPreference> GetCustomerPreference(Guid customerId, Guid preferenceId);
    }
}

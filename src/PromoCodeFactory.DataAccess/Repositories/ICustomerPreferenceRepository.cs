using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public interface ICustomerPreferenceRepository
    {
        Task AddPreferenceToCustomerAsync(CustomerPreference customerPreference);
        Task RemovePreferenceFromCustomerAsync(Guid customerId, Guid preferenceId);
        Task<List<Preference>> GetPreferencesByCustomerAsync(Guid customerId);
        Task<List<Customer>> GetCustomersByPreferenceAsync(Guid preferenceId);

        Task<CustomerPreference> GetCustomerPreference(Guid customerId, Guid preferenceId);
    }
}

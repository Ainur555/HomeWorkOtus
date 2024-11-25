using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pcf.GivingToCustomer.Core.Domain;
using Pcf.GivingToCustomer.WebHost.Models;

namespace Pcf.GivingToCustomer.WebHost.Mappers
{
    public class CustomerMapper
    {

        public static Customer MapFromModel(CreateOrEditCustomerRequest model, IEnumerable<Preference> preferences = null, Customer customer = null)
        {
            if(customer == null)
            {
                customer = new Customer();
                customer.Id = Guid.NewGuid();
            }
            
            customer.FirstName = !string.IsNullOrWhiteSpace(model.FirstName) ? model.FirstName : customer.FirstName;
            customer.LastName = !string.IsNullOrWhiteSpace(model.LastName) ? model.LastName : customer.LastName;
            customer.Email = !string.IsNullOrWhiteSpace(model.Email) ? model.Email : customer.Email;

            if (preferences != null)
            {
                customer.Preferences = preferences.Select(x => new CustomerPreference()
                {
                    CustomerId = customer.Id,
                    Preference = x,
                    PreferenceId = x.Id
                }).ToList();
            }

            return customer;
        }
    }
}

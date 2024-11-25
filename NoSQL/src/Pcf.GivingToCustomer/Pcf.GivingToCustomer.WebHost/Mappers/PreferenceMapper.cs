using Pcf.GivingToCustomer.Core.Domain;
using Pcf.GivingToCustomer.WebHost.Models;
using System.Collections.Generic;
using System;

namespace Pcf.GivingToCustomer.WebHost.Mappers
{
    public class PreferenceMapper
    {
        public static Preference MapFromModel(CreateOrEditPreference model, Preference preference = null)
        {
            if (preference == null)
            {
                preference = new Preference();
                preference.Id = Guid.NewGuid();
            }

            preference.Name = model.Name;
         
            return preference;
        }
    }
}

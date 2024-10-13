using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts.PromoCodes;
using PromoCodeFactory.DataAccess.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoCodeFactory.DataAccess.Contracts.Preferences;

namespace PromoCodeFactory.DataAccess.Contracts
{
    public class CustomerResponseDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public List<PromoCodeShortResponseDto> PromoCodes { get; set; }
        public List<PreferencesDto> Preferences { get; set; }
    }
}

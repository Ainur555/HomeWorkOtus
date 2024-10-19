using System.Collections.Generic;
using System;
using PromoCodeFactory.WebHost.Models.PromoCodes;

namespace PromoCodeFactory.WebHost.Models
{
    public class CustomerModel
    {
        public Guid Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }

        public List<PromoCodeModel> PromoCodes { get; init; }
    }
}

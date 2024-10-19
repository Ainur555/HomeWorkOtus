using System.Collections.Generic;
using System;

namespace PromoCodeFactory.WebHost.Models
{
    public class CreateOrEditCustomerRequest
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }
        public List<Guid> PreferenceIds { get; init; }
    }
}

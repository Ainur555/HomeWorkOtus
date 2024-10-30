using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models.Request
{
    public class CreateOrEditCustomerRequest
    {
        [Required]
        public required string FirstName { get; init; }
        [Required]
        public required string LastName { get; init; }
        [Required]
        public required string Email { get; init; }
        public List<Guid> PreferenceIds { get; init; }
    }
}

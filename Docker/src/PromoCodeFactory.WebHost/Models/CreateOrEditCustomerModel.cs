using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace PromoCodeFactory.WebHost.Models
{
    public class CreateOrEditCustomerModel
    {
        [Required]
        public required string FirstName { get; init; }
        [Required]
        public required string LastName { get; init; }
        [Required]
        public required string Email { get; init; }
        [Required]
        public List<Guid> PreferenceIds { get; init; }
    }
}

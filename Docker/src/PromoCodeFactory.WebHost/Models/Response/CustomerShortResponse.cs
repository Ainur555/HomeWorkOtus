using PromoCodeFactory.WebHost.Models.PromoCodes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models.Response
{
    public class CustomerShortResponse
    {
        public Guid Id { get; init; }
        [Required]
        public required string FirstName { get; init; }
        [Required]
        public required string LastName { get; init; }
        [Required]
        public required string Email { get; init; }

    }
}

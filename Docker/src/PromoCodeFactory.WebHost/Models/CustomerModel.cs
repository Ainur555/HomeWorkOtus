using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PromoCodeFactory.WebHost.Models.PromoCodes;

namespace PromoCodeFactory.WebHost.Models
{
    public class CustomerModel
    {
        public Guid Id { get; init; }
        [Required]
        public required string FirstName { get; init; }
        [Required]
        public required string LastName { get; init; }
        [Required]
        public required string Email { get; init; }

        [Required]
        public List<PromoCodeModel> PromoCodes { get; init; }
    }
}

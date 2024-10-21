using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PromoCodeFactory.WebHost.Models.Preferences;
using PromoCodeFactory.WebHost.Models.PromoCodes;

namespace PromoCodeFactory.WebHost.Models
{
    public class CustomerResponse
    {
        public Guid Id { get; init; }
        [Required]
        public required string FirstName { get; init; }
        [Required]
        public required string LastName { get; init; }
        [Required]
        public required string Email { get; init; }

        [Required]
        public List<PromoCodeShortResponse> PromoCodes { get; set; }
        [Required]
        public List<PreferencesModel> Preferences { get; set; }
    }
}

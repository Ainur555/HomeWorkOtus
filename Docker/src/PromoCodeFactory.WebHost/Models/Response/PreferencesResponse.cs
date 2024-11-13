using System.ComponentModel.DataAnnotations;
using System;

namespace PromoCodeFactory.WebHost.Models.Response
{
    public class PreferencesResponse
    {
        public Guid Id { get; init; }
        [Required]
        public required string Name { get; init; }
    }
}

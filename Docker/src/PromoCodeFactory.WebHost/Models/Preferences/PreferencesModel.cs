using System;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models.Preferences
{
    public class PreferencesModel
    {
        public Guid Id { get; init; }
        [Required]
        public required string Name { get; init; }
    }
}

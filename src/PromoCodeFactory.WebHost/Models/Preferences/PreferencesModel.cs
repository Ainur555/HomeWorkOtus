using System;

namespace PromoCodeFactory.WebHost.Models.Preferences
{
    public class PreferencesModel
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
    }
}

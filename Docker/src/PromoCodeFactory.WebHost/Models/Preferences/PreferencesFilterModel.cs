using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models.Preferences
{
    public class PreferencesFilterModel
    {
        public required string Name { get; init; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}

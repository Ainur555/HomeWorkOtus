using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models
{
    public class RoleCreate
    {
        [Required]
        public required string Name { get; init; }

        [Required]
        public string Description { get; init; }
    }
}

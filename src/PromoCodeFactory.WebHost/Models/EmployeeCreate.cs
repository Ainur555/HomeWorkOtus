using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models
{
    public class EmployeeCreate
    {
        [Required]
        public required string FirstName { get; init; }
        [Required]
        public required string LastName { get; init; }

        [Required]
        public RoleCreate Role { get; init; }
        [Required]
        public required string Email { get; init; }

        public int AppliedPromocodesCount { get; init; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models
{
    public class EmployeeUpdate
    {
        [Required]
        public required string FirstName { get; init; }
        [Required]
        public required string LastName { get; init; }
        [Required]
        public required string Email { get; init; }

        public int AppliedPromocodesCount { get; init; }
    }
}

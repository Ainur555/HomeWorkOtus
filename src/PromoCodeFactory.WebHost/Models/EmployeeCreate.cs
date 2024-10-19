using System.Collections.Generic;

namespace PromoCodeFactory.WebHost.Models
{
    public class EmployeeCreate
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }

        public RoleCreate Role { get; init; }
        public required string Email { get; init; }

        public int AppliedPromocodesCount { get; init; }
    }
}

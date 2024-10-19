using System;
using System.Collections.Generic;

namespace PromoCodeFactory.WebHost.Models
{
    public class EmployeeResponse
    {
        public Guid Id { get; init; }
        public required string FullName { get; init; }

        public required string Email { get; init; }

        public RoleItemResponse Role { get; init; }

        public int AppliedPromocodesCount { get; init; }
    }
}
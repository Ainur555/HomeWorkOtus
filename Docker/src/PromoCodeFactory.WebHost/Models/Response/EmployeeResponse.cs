using System;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models.Response
{
    public class EmployeeResponse
    {
        public Guid Id { get; init; }
        [Required]
        public required string FullName { get; init; }

        [Required]
        public required string Email { get; init; }

        [Required]
        public RoleItemResponse Role { get; init; }

        public int AppliedPromocodesCount { get; init; }
    }
}
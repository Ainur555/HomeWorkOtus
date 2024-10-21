using System;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models
{
    public class EmployeeShortResponse
    {
        public Guid Id { get; init; }

        [Required]
        public required string FullName { get; init; }

        [Required]
        public required string Email { get; init; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models
{
    public class СustomerFilterModel
    {
        public Guid Id { get; init; }
        [Required]
        public required string FirstName { get; init; }
        [Required]
        public required string LastName { get; init; }
        [Required]
        public required string Email { get; init; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}

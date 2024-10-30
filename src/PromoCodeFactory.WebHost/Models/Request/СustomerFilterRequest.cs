using System.ComponentModel.DataAnnotations;
using System;

namespace PromoCodeFactory.WebHost.Models.Request
{
    public class СustomerFilterRequest
    {
        public Guid Id { get; init; }
        [Required]
        public string FirstName { get; init; }
        [Required]
        public string LastName { get; init; }
        [Required]
        public string Email { get; init; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}

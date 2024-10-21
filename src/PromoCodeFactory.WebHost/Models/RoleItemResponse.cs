using System;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models
{
    public class RoleItemResponse
    {
        public Guid Id { get; init; }

        [Required]
        public required string Name { get; init; }

        [Required]
        public required string Description { get; init; }
    }
}
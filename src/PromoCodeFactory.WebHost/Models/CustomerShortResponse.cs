using System;

namespace PromoCodeFactory.WebHost.Models
{
    public class CustomerShortResponse
    {
        public Guid Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }
    }
}

using System;

namespace PromoCodeFactory.WebHost.Models
{
    public class EmployeeShortResponse
    {
        public Guid Id { get; init; }
        
        public required string FullName { get; init; }

        public required string Email { get; init; }
    }
}
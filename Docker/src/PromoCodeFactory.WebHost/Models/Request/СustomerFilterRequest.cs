using System.ComponentModel.DataAnnotations;
using System;

namespace PromoCodeFactory.WebHost.Models.Request
{
    public class СustomerFilterRequest
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}

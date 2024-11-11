using System;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models
{
    public class СustomerFilterModel
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}

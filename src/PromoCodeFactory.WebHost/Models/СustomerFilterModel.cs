using System;

namespace PromoCodeFactory.WebHost.Models
{
    public class СustomerFilterModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
    }
}

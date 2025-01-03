﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class Customer : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public required string Email { get; set; }

        public List<PromoCode> PromoCodes { get; set; }
        public List<CustomerPreference> Preferences { get; set; }

        public Customer()
        {
            PromoCodes = new List<PromoCode>();
            Preferences = new List<CustomerPreference>();
        }
    }
}

﻿using System.Collections.Generic;

namespace PromoCodeFactory.WebHost.Models
{
    public class EmployeeCreate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public RoleCreate Role { get; set; }
        public string Email { get; set; }

        public int AppliedPromocodesCount { get; set; }
    }
}

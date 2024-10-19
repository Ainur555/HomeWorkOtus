﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Contracts
{
    public class PreferencesFilterDto
    {
        public required string Name { get; init; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}

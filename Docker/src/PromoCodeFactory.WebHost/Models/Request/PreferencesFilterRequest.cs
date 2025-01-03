﻿using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models.Request
{
    public class PreferencesFilterRequest
    {
        public required string Name { get; init; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}

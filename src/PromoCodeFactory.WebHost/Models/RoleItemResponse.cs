﻿using System;

namespace PromoCodeFactory.WebHost.Models
{
    public class RoleItemResponse
    {
        public Guid Id { get; init; }

        public required string Name { get; init; }

        public string Description { get; init; }
    }
}
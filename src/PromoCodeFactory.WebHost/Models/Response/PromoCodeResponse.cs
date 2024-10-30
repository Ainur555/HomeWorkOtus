﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models.Response
{
    public class PromoCodeResponse
    {
        [Required]
        public required string Code { get; init; }
        [Required]
        public required string ServiceInfo { get; init; }
        [Required]
        public DateTime BeginDate { get; init; }
        [Required]
        public DateTime EndDate { get; init; }
    }
}

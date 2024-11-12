﻿using System;

namespace PromoCodeFactory.WebHost.Models.PromoCodes
{
    public class GivePromoCodeModel
    {
        public required string ServiceInfo { get; init; }
        public required string PromoCode { get; init; }
        public required string BeginDate { get; init; }
        public required string EndDate { get; init; }
        public required string PartnerName { get; init; }
        public Guid EmployeeId { get; init; }
        public Guid PreferenceId { get; init; }
    }
}
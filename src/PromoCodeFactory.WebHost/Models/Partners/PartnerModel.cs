using PromoCodeFactory.DataAccess.Contracts.Partners;
using System.Collections.Generic;
using System;

namespace PromoCodeFactory.WebHost.Models.Partners
{
    public class PartnerModel
    {
        public Guid Id { get; set; }
        public required string Name { get; init; }
        public int NumberIssuedPromoCodes { get; init; }
        public bool IsActive { get; init; }
        public List<PartnerPromoCodeLimitDto> PartnerLimits { get; set; } = [];
    }
}

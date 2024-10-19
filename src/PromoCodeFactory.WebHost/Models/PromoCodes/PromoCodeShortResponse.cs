using System;

namespace PromoCodeFactory.WebHost.Models.PromoCodes
{
    public class PromoCodeShortResponse
    {
        public Guid Id { get; init; }

        public required string Code { get; init; }

        public required string ServiceInfo { get; init; }

        public required string BeginDate { get; init; }

        public required string EndDate { get; init; }

        public required string PartnerName { get; init; }
    }
}

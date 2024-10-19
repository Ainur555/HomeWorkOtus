using System;

namespace PromoCodeFactory.WebHost.Models.PromoCodes
{
    public class PromoCodeShortResponse
    {
        public Guid Id { get; init; }

        public required string Code { get; init; }

        public required string ServiceInfo { get; init; }

        public string BeginDate { get; init; }

        public string EndDate { get; init; }

        public string PartnerName { get; init; }
    }
}

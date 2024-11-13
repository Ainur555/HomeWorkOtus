using System;

namespace PromoCodeFactory.WebHost.Models.PromoCodes
{
    public class PromoCodeModel
    {
        public required string Code { get; init; }

        public required string ServiceInfo { get; init; }

        public DateTime BeginDate { get; init; }

        public DateTime EndDate { get; init; }
    }
}

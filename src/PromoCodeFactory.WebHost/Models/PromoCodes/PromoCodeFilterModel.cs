using System;

namespace PromoCodeFactory.WebHost.Models.PromoCodes
{
    public class PromoCodeFilterModel
    {
        public  string Code { get; init; }

        public string ServiceInfo { get; init; }

        public string PartnerName { get; init; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}

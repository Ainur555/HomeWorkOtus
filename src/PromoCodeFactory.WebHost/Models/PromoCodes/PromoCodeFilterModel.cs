using System;

namespace PromoCodeFactory.WebHost.Models.PromoCodes
{
    public class PromoCodeFilterModel
    {
        public string Code { get; set; }

        public string ServiceInfo { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public string PartnerName { get; set; }

        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
    }
}

using System;

namespace PromoCodeFactory.WebHost.Models.PromoCodes
{
    public class PromoCodeModel
    {
        public string Code { get; set; }

        public string ServiceInfo { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}

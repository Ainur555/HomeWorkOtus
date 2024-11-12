using System;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models.Request
{
    public class PromoCodeFilterRequest
    {
        public string Code { get; init; }
        public string ServiceInfo { get; init; }
     
        public string PartnerName { get; init; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}

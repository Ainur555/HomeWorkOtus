using System;
using System.ComponentModel.DataAnnotations;

namespace PromoCodeFactory.WebHost.Models.Request
{
    public class PromoCodeFilterRequest
    {
        [Required]
        public string Code { get; init; }
        [Required]
        public string ServiceInfo { get; init; }
        public DateTime BeginDate { get; init; }
        public DateTime EndDate { get; init; }
        [Required]
        public string PartnerName { get; init; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }
    }
}

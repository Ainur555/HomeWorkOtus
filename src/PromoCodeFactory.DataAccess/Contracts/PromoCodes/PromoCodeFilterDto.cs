using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Contracts.PromoCodes
{
    public class PromoCodeFilterDto
    {
        public required string Code { get; init; }

        public required string ServiceInfo { get; init; }

        public DateTime BeginDate { get; init; }

        public DateTime EndDate { get; init; }

        public string PartnerName { get; init; }

        public int ItemsPerPage { get; init; }
        public int Page { get; init; }

    }
}

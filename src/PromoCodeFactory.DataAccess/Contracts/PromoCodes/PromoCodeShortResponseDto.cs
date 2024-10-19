using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Contracts.PromoCodes
{
    public class PromoCodeShortResponseDto
    {
        public Guid Id { get; init; }

        public required string Code { get; init; }

        public required string ServiceInfo { get; init; }

        public required string BeginDate { get; init; }

        public required string EndDate { get; init; }

        public string PartnerName { get; init; }
    }
}

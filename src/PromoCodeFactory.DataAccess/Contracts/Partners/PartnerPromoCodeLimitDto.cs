using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Contracts.Partners
{
    public class PartnerPromoCodeLimitDto
    {
        public Guid Id { get; set; }
        public int Limit { get; init; }
        public string CreateDate { get; init; }
        public required string EndDate { get; init; }
        public required string CancelDate { get; init; }

        public Guid PartnerId { get; init; }
        public PartnerDto Partner { get; init; }
    }
}

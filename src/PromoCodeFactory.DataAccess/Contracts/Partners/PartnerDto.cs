using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Contracts.Partners
{
    public class PartnerDto
    {
        public Guid Id { get; set; }
        public required string Name { get; init; }
        public int NumberIssuedPromoCodes { get; init; }
        public bool IsActive { get; init; }
        public List<PartnerPromoCodeLimitDto> PartnerLimits { get; set; } = [];
    }
}

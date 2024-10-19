using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Contracts.Partners
{
    public class PartnerPromoCodeLimitRequestDto
    {
        public required string EndDate { get; set; }
        public int Limit { get; set; }
    }
}

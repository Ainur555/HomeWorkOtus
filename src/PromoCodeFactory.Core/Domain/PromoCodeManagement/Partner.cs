using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class Partner : BaseEntity
    {
        public required string Name { get; set; }
        public int NumberIssuedPromoCodes { get; set; }
        public bool IsActive { get; set; }
        public ICollection<PartnerPromoCodeLimit> PartnerLimits { get; set; }
    }
}

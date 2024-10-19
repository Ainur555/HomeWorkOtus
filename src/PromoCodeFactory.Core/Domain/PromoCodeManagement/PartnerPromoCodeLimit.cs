using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class PartnerPromoCodeLimit : BaseEntity
    {
        public int Limit { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? CancelDate { get; set; }

        public Guid PartnerId { get; set; }
        public Partner Partner { get; set; }
    }
}

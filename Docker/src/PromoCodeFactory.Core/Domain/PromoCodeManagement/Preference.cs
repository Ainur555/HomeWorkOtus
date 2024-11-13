using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class Preference : BaseEntity
    {
        public required string Name { get; set; }

        public ICollection<PromoCode> Promocodes { get; set; }

        public Preference()
        {
            Promocodes = new List<PromoCode>();
        }
    }
}

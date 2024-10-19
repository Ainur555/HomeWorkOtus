using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Contracts.PromoCodes
{
    public class PromoCodeDto
    {
        public required string Code { get; init; }

        public required string ServiceInfo { get; init; }

        public DateTime BeginDate { get; init; }

        public DateTime EndDate { get; init; }

    }
}

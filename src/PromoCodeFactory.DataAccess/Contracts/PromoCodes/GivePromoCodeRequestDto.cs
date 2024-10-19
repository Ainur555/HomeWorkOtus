using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Contracts.PromoCodes
{
    public class GivePromoCodeRequestDto
    {
        public required string ServiceInfo { get; init; }
        public required string PartnerName { get; init; }
        public required string PromoCode { get; init; }
        public required string BeginDate { get; init; }
        public required string EndDate { get; init; }
        public Guid EmployeeId { get; init; }
        public Guid PreferenceId { get; init; }
    }
}

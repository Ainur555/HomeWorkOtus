using PromoCodeFactory.Core.Domain.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.Core.Domain.PromoCodeManagement
{
    public class PromoCode : BaseEntity
    {
        public required string Code { get; set; }

        public required string ServiceInfo { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

        public required string PartnerName { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee PartnerManager { get; set; }

        public Guid PreferenceId { get; set; }
        public Preference Preference { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}

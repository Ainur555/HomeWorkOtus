using PromoCodeFactory.DataAccess.Contracts.PromoCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Contracts
{
    public class CustomerDto
    {
        public Guid Id { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string Email { get; init; }

        public List<PromoCodeDto> PromoCodes { get; init; }
    }
}

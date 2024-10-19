using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PromoCodeFactory.DataAccess.Contracts.Partners;

namespace PromoCodeFactory.WebHost.Services.Partners
{
    public  interface IPartnerService
    {
        Task<List<PartnerDto>> GetAllAsync();
        Task<PartnerPromoCodeLimitDto> GetPartnerLimitAsync(Guid id, Guid limitId);
        Task<PartnerPromoCodeLimitDto> SetPartnerPromoCodeLimitAsync(Guid id, PartnerPromoCodeLimitRequestDto request);
        Task CancelPartnerPromoCodeLimitAsync(Guid id);
    }
}

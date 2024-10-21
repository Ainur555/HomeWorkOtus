using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PromoCodeFactory.DataAccess.Contracts.PromoCodes;

namespace PromoCodeFactory.WebHost.Services.PromoCodes
{
    public interface IPromoCodeService
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список Промокодов. </returns>
        Task<ICollection<PromoCodeDto>> GetPagedAsync(PromoCodeFilterDto filterDto, CancellationToken cancellationToken);

        Task GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeRequestDto request, CancellationToken cancellationToken);
    }
}

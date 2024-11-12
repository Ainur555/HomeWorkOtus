using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts.PromoCodes;
using PromoCodeFactory.WebHost.Models.PromoCodes;

namespace PromoCodeFactory.WebHost.Services.PromoCodes
{
    public interface IPromoCodeService
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterModel"> Модель фильтра. </param>
        /// <param name="cancellationToken"> токен отмены </param>
        /// <returns> Список Промокодов. </returns>
        Task<ICollection<PromoCode>> GetPagedAsync(PromoCodeFilterModel filterModel, CancellationToken cancellationToken);


        /// <summary>
        /// Получить все промокоды
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>Список промокодов</returns>
        Task<List<PromoCode>> GetAllAsync(CancellationToken cancellationToken);

        Task GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeModel givePromoCodeModel, CancellationToken cancellationToken);
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts.PromoCodes;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public interface IPromoCodeRepository : IRepository<PromoCode>
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список клиентов </returns>
        Task<List<PromoCode>> GetPagedAsync(PromoCodeFilterDto filterDto, CancellationToken cancellationToken);

        /// <summary>
        /// Получить список промокодов по клиенту
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<List<PromoCode>> GetByCustomerId(Guid customerId, CancellationToken cancellationToken);
    }
}

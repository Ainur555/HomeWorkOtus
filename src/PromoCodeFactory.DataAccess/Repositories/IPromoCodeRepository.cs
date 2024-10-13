using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.DataAccess.Contracts.PromoCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public interface IPromoCodeRepository : IRepository<PromoCode>
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список клиентов </returns>
        Task<List<PromoCode>> GetPagedAsync(PromoCodeFilterDto filterDto);

        /// <summary>
        /// Получить список промокодов по клиенту
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task<List<PromoCode>> GetByCustomerId(Guid customerId);
    }
}

using PromoCodeFactory.Core.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список клиентов </returns>
        Task<List<Customer>> GetPagedAsync(CustomerFilterDto filterDto);
    }
}

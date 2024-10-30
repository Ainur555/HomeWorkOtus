using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Получить клиента
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns> клиент </returns>
        Task<Customer> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Создать клиента
        /// </summary>
        /// <param name="creatingCustomerModel"> Модель редактируемого клиента. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task<Customer> CreateAsync(CreateOrEditCustomerModel creatingCustomerModel, CancellationToken cancellationToken);

        /// <summary>
        /// Изменить клиента
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="updatingCustomerModel"> Модель редактируемого клиента. </param>
        Task<Customer> UpdateAsync(Guid id, CreateOrEditCustomerModel updatingCustomerModel, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить клиента
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);

        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterModel"> модель фильтра </param>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns> Список клиентов. </returns>
        Task<ICollection<Customer>> GetPagedAsync(СustomerFilterModel filterModel, CancellationToken cancellationToken);
    }
}

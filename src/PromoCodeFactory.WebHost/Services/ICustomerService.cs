using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.WebHost.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Services
{
    public interface ICustomerService
    {
        /// <summary>
        /// Получить клиента
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        /// <returns> ДТО клиента. </returns>
        Task<CustomerDto> GetByIdAsync(Guid id);

        /// <summary>
        /// Создать клиента
        /// </summary>
        /// <param name="creatingCustomerDto"> ДТО создаваемого клиента. </param>
        Task<CustomerResponseDto> CreateAsync(CreateOrEditCustomerRequestDto creatingCustomerDto);

        /// <summary>
        /// Изменить клиента
        /// </summary>
        /// <param name="id"> Иентификатор. </param>
        /// <param name="updatingCustomerDto"> ДТО редактируемого клиента. </param>
        Task<CustomerResponseDto> UpdateAsync(Guid id, CreateOrEditCustomerRequestDto updatingCustomerDto);

        /// <summary>
        /// Удалить клиента
        /// </summary>
        /// <param name="id"> Идентификатор. </param>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список клиентов. </returns>
        Task<ICollection<CustomerDto>> GetPagedAsync(CustomerFilterDto filterDto);
    }
}

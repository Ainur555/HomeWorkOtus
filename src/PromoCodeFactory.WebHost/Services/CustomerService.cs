using System.Threading.Tasks;
using System.Threading;
using System;
using PromoCodeFactory.DataAccess.Repositories;
using AutoMapper;
using System.Collections.Generic;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using System.Linq;
using PromoCodeFactory.WebHost.Models;
using PromoCodeFactory.DataAccess.Contracts;
using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.DataAccess.Contracts.PromoCodes;
using PromoCodeFactory.DataAccess.Contracts.Preferences;

namespace PromoCodeFactory.WebHost.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPreferenceRepository _preferenceRepository;
        private readonly IPromoCodeRepository _promoCodeRepository;
        private readonly ICustomerPreferenceRepository _customerPreferenceRepository;

        public CustomerService(
            IMapper mapper,
            ICustomerRepository courseRepository,
            IPreferenceRepository preferenceRepository,
            ICustomerPreferenceRepository customerPreferenceRepository,
            IPromoCodeRepository promoCodeRepository)
        {
            _mapper = mapper;
            _customerRepository = courseRepository;
            _preferenceRepository = preferenceRepository;
            _customerPreferenceRepository = customerPreferenceRepository;
            _promoCodeRepository = promoCodeRepository;
        }

        async Task<CustomerDto> ICustomerService.GetByIdAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id, default);

            return _mapper.Map<Customer, CustomerDto>(customer);
        }

        /// <summary>
        /// Создание клиента
        /// </summary>
        /// <param name="creatingCustomerDto"></param>
        /// <returns></returns>
        public async Task<CustomerResponseDto> CreateAsync(CreateOrEditCustomerRequestDto creatingCustomerDto)
        {
            var customer        = _mapper.Map<CreateOrEditCustomerRequestDto, Customer>(creatingCustomerDto);
            var createdCustomer = await _customerRepository.AddAsync(customer, default);
                 
            await _customerRepository.SaveChangesAsync(default);

            var preferences = await _customerPreferenceRepository.GetPreferencesByCustomerAsync(createdCustomer.Id, default);

            return new CustomerResponseDto()
            {
                Id = createdCustomer.Id,
                FirstName = createdCustomer.FirstName,
                LastName = createdCustomer.LastName,
                Email = createdCustomer.Email,
                Preferences = preferences.Select(x => new PreferencesDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };
        }

        public async Task<CustomerResponseDto> UpdateAsync(Guid id, CreateOrEditCustomerRequestDto updatingCustomerDto)
        {
            var customer = await _customerRepository.GetByIdAsync(id, default);

            if (customer == null)
            {
                throw new Exception($"Клиент с идентфикатором {id} не найден");
            }

            customer.FirstName = !string.IsNullOrWhiteSpace(updatingCustomerDto.FirstName) ? updatingCustomerDto.FirstName : customer.FirstName;
            customer.LastName = !string.IsNullOrWhiteSpace(updatingCustomerDto.LastName) ? updatingCustomerDto.LastName : customer.LastName;
            customer.Email    = !string.IsNullOrWhiteSpace(updatingCustomerDto.Email) ? updatingCustomerDto.Email : customer.Email;
           
            _customerRepository.Update(customer);
            await _customerRepository.SaveChangesAsync(default);

            var preferences = await _customerPreferenceRepository.GetPreferencesByCustomerAsync(customer.Id, default);

            return new CustomerResponseDto()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                Preferences = preferences.Select(x => new PreferencesDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };
        }
      
        async Task ICustomerService.DeleteAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id, default);

            if (customer == null)
            {
                throw new Exception($"Клиент с идентфикатором {id} не найден");
            }            

            _customerRepository.Delete(id);

            await _customerRepository.SaveChangesAsync(default);
        }

        public async Task<ICollection<CustomerDto>> GetPagedAsync(CustomerFilterDto filterDto)
        {
            ICollection<Customer> entities = await _customerRepository.GetPagedAsync(filterDto);
            return _mapper.Map<ICollection<Customer>, ICollection<CustomerDto>>(entities);
        }


    }
}

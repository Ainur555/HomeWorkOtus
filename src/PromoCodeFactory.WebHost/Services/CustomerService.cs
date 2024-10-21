using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.DataAccess.Contracts.Preferences;
using PromoCodeFactory.DataAccess.Repositories;

namespace PromoCodeFactory.WebHost.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerPreferenceRepository _customerPreferenceRepository;

        public CustomerService(
            IMapper mapper,
            ICustomerRepository courseRepository,
            ICustomerPreferenceRepository customerPreferenceRepository)
        {
            _mapper = mapper;
            _customerRepository = courseRepository;
            _customerPreferenceRepository = customerPreferenceRepository;
        }

        async Task<CustomerDto> ICustomerService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(id, cancellationToken);

            return _mapper.Map<Customer, CustomerDto>(customer);
        }

        /// <summary>
        /// Создание клиента
        /// </summary>
        /// <param name="creatingCustomerDto"></param>
        /// <returns></returns>
        public async Task<CustomerResponseDto> CreateAsync(CreateOrEditCustomerRequestDto creatingCustomerDto, CancellationToken cancellationToken)
        {
            var customer        = _mapper.Map<CreateOrEditCustomerRequestDto, Customer>(creatingCustomerDto);
            var createdCustomer = await _customerRepository.AddAsync(customer, cancellationToken);

            await _customerRepository.SaveChangesAsync(cancellationToken);

            var preferences = await _customerPreferenceRepository.GetPreferencesByCustomerAsync(createdCustomer.Id, cancellationToken);

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

        public async Task<CustomerResponseDto> UpdateAsync(Guid id, CreateOrEditCustomerRequestDto updatingCustomerDto, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(id, cancellationToken);

            if (customer == null)
            {
                throw new Exception($"Клиент с идентфикатором {id} не найден");
            }

            customer.FirstName = !string.IsNullOrWhiteSpace(updatingCustomerDto.FirstName) ? updatingCustomerDto.FirstName : customer.FirstName;
            customer.LastName = !string.IsNullOrWhiteSpace(updatingCustomerDto.LastName) ? updatingCustomerDto.LastName : customer.LastName;
            customer.Email    = !string.IsNullOrWhiteSpace(updatingCustomerDto.Email) ? updatingCustomerDto.Email : customer.Email;

            _customerRepository.Update(customer);
            await _customerRepository.SaveChangesAsync(cancellationToken);

            var preferences = await _customerPreferenceRepository.GetPreferencesByCustomerAsync(customer.Id, cancellationToken);

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

        async Task ICustomerService.DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(id, cancellationToken);

            if (customer == null)
            {
                throw new Exception($"Клиент с идентфикатором {id} не найден");
            }

            _customerRepository.Delete(id);

            await _customerRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<ICollection<CustomerDto>> GetPagedAsync(CustomerFilterDto filterDto, CancellationToken cancellationToken)
        {
            ICollection<Customer> entities = await _customerRepository.GetPagedAsync(filterDto, cancellationToken);
            return _mapper.Map<ICollection<Customer>, ICollection<CustomerDto>>(entities);
        }


    }
}

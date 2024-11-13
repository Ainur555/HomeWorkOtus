using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.DataAccess.Repositories;
using PromoCodeFactory.WebHost.Models;

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

        async Task<Customer> ICustomerService.GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetByIdAsync(id, cancellationToken, nameof(Customer.PromoCodes));
        }

        public async Task<Customer> CreateAsync(CreateOrEditCustomerModel creatingCustomerModel, CancellationToken cancellationToken)
        {
            var customer        = _mapper.Map<CreateOrEditCustomerModel, Customer>(creatingCustomerModel);
            var createdCustomer = await _customerRepository.AddAsync(customer, cancellationToken);

            await _customerRepository.SaveChangesAsync(cancellationToken);

            return customer;
        }

        public async Task<Customer> UpdateAsync(Guid id, CreateOrEditCustomerModel updatingCustomerDto, CancellationToken cancellationToken)
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

            return customer;
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

        public async Task<ICollection<Customer>> GetPagedAsync(СustomerFilterModel filterModel, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetPagedAsync(_mapper.Map<СustomerFilterModel, CustomerFilterDto>(filterModel), cancellationToken);
        }

        public async Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _customerRepository.GetAllAsync(cancellationToken);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pcf.GivingToCustomer.Core.Abstractions.Repositories;
using Pcf.GivingToCustomer.Core.Domain;
using Pcf.GivingToCustomer.WebHost.Mappers;
using Pcf.GivingToCustomer.WebHost.Models;

namespace Pcf.GivingToCustomer.WebHost.Controllers
{
    /// <summary>
    /// Клиенты
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomersController
        : ControllerBase
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Preference> _preferenceRepository;

        public CustomersController(IRepository<Customer> customerRepository, 
            IRepository<Preference> preferenceRepository)
        {
            _customerRepository = customerRepository;
            _preferenceRepository = preferenceRepository;
        }
        
        /// <summary>
        /// Получить список клиентов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<CustomerShortResponse>>> GetCustomersAsync()
        {
            var customers =  await _customerRepository.GetAllAsync(HttpContext.RequestAborted);

            var response = customers.Select(x => new CustomerShortResponse()
            {
                Id = x.Id,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();

            return Ok(response);
        }
        
        /// <summary>
        /// Получить клиента по id
        /// </summary>
        /// <param name="id">Id клиента, например <example>a6c8c6b1-4349-45b0-ab31-244740aaf0f0</example></param>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CustomerResponse>> GetCustomerAsync(Guid id)
        {
            var customer =  await _customerRepository.GetByIdAsync(id, HttpContext.RequestAborted);

            var response = new CustomerResponse(customer);

            return Ok(response);
        }
        
        /// <summary>
        /// Создать нового клиента
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CustomerResponse>> CreateCustomerAsync(CreateOrEditCustomerRequest request)
        {
            //Получаем предпочтения из бд и сохраняем большой объект
            var preferences = await _preferenceRepository
                .GetRangeByIdsAsync(request.PreferenceIds, HttpContext.RequestAborted);

            Customer customer = CustomerMapper.MapFromModel(request, preferences);
            
            await _customerRepository.AddAsync(customer, HttpContext.RequestAborted);

            return CreatedAtAction(nameof(GetCustomerAsync), new {id = customer.Id}, customer.Id);
        }
        
        /// <summary>
        /// Обновить клиента
        /// </summary>
        /// <param name="id">Id клиента, например <example>a6c8c6b1-4349-45b0-ab31-244740aaf0f0</example></param>
        /// <param name="request">Данные запроса></param>
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> EditCustomersAsync(Guid id, CreateOrEditCustomerRequest request)
        {
            var customer = await _customerRepository.GetByIdAsync(id, HttpContext.RequestAborted);
            
            if (customer == null)
                return NotFound();         
           
            if(request.PreferenceIds != null)
            {
                var preferences = await _preferenceRepository.GetRangeByIdsAsync(request.PreferenceIds, HttpContext.RequestAborted);
                CustomerMapper.MapFromModel(request, preferences, customer);
            }
            else
            {
                CustomerMapper.MapFromModel(request, customer:customer);
            }
   

            await _customerRepository.UpdateAsync(id, customer, HttpContext.RequestAborted);

            return Ok($"Клиент с id {id} обновлен");
        }
        
        /// <summary>
        /// Удалить клиента
        /// </summary>
        /// <param name="id">Id клиента, например <example>a6c8c6b1-4349-45b0-ab31-244740aaf0f0</example></param>
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCustomerAsync(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id, HttpContext.RequestAborted);
            
            if (customer == null)
                return NotFound();

            await _customerRepository.DeleteAsync(id, HttpContext.RequestAborted);

            return Ok($"Клиент с id {id} удален");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.WebHost.Models;
using PromoCodeFactory.WebHost.Models.Request;
using PromoCodeFactory.WebHost.Models.Response;
using PromoCodeFactory.WebHost.Services;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Клиенты
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка клиентов
        /// </summary>
        /// <param name="filterModel"><СustomerFilterModel/param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<ActionResult<CustomerShortResponse>> GetCustomersAsync(СustomerFilterRequest request)
        {
            var filterModel = _mapper.Map<СustomerFilterRequest, СustomerFilterModel>(request);
            var response = _mapper.Map<List<CustomerShortResponse>>(await _service.GetPagedAsync(filterModel, HttpContext.RequestAborted));
            return Ok(response);
        }

        /// <summary>
        /// Получение клиента через гуид
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerShortResponse>> GetCustomerAsync(Guid id)
        {
            return Ok(_mapper.Map<CustomerShortResponse>(await _service.GetByIdAsync(id, HttpContext.RequestAborted)));
        }

        /// <summary>
        /// Создание клиента вместе с предпочтениями
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CustomerResponse>> CreateCustomerAsync(CreateOrEditCustomerRequest request)
        {
            return Ok(await _service.CreateAsync(_mapper.Map<CreateOrEditCustomerModel>(request), HttpContext.RequestAborted));
        }

        /// <summary>
        /// Изменение клиента по гуиду
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public async Task<ActionResult<CustomerResponse>> EditCustomersAsync(Guid id, CreateOrEditCustomerRequest request)
        {
            return Ok(await _service.UpdateAsync(id, _mapper.Map<CreateOrEditCustomerRequest, CreateOrEditCustomerModel>(request), HttpContext.RequestAborted));
        }

        /// <summary>
        /// Удаление клиента по гуиду
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            await _service.DeleteAsync(id, HttpContext.RequestAborted);
            return Ok($"Сотрудник с id {id} удален");
        }
    }
}

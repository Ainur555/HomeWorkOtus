using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.Core.Abstractions.Repositories;
using PromoCodeFactory.Core.Domain.Administration;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Сотрудники
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeesController(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        /// <summary>
        /// Получить данные всех сотрудников
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<EmployeeShortResponse>> GetEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync(HttpContext.RequestAborted);

            var employeesModelList = employees.Select(x =>
                new EmployeeShortResponse()
                {
                    Id = x.Id,
                    Email = x.Email,
                    FullName = x.FullName,
                }).ToList();

            return employeesModelList;
        }

        /// <summary>
        /// Получить данные сотрудника по Id
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<EmployeeResponse>> GetEmployeeByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id, default);

            if (employee == null)
                return NotFound();

            var employeeModel = new EmployeeResponse()
            {
                Id = employee.Id,
                Email = employee.Email,
                Role = new RoleItemResponse()
                {
                    Name = employee.Role.Name,
                    Description = employee.Role.Description
                },
                FullName = employee.FullName,
                AppliedPromocodesCount = employee.AppliedPromocodesCount
            };

            return employeeModel;
        }

        /// <summary>
        /// Удалить  сотрудника по Id
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<string>> DeleteEmployeeByIdAsync(Guid id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id, default);

            if (employee == null)
            {
                return NotFound($"Сотрудник с id {id} не найден");
            }

            _employeeRepository.Delete(id);

            return Ok($"Сотрудник с id {id} удален");
        }

        /// <summary>
        /// Создать сотрудника
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<EmployeeResponse>> CreateEmployeeAsync(EmployeeCreate request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.FirstName) || string.IsNullOrWhiteSpace(request.LastName))
            {
                return BadRequest("Некорректные данные для создания сотрудника");
            }

            var newEmployee = new Employee
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Role = new Role()
                {
                    Id          = Guid.NewGuid(),
                    Name        = request.Role.Name,
                    Description = request.Role.Description
                },
            };

            await _employeeRepository.AddAsync(newEmployee, default);

            var employeeResponse = new EmployeeResponse
            {
                Id = newEmployee.Id,
                FullName = newEmployee.FullName,
                Email = newEmployee.Email,
                Role = new RoleItemResponse()
                {
                    Name = newEmployee.Role.Name,
                    Description = newEmployee.Role.Description
                },
                AppliedPromocodesCount = newEmployee.AppliedPromocodesCount
            };

            return Ok(employeeResponse);
        }




        /// <summary>
        /// Обновить сотрудника
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<EmployeeResponse>> UpdateEmployeeAsync(Guid id, EmployeeUpdate request)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(id, default);

            if (existingEmployee == null)
            {
                return NotFound($"Сотрудник с id {id} не найден");
            }

            // Обновление данных сотрудника
            existingEmployee.Email                  = !string.IsNullOrWhiteSpace(request.Email) ? request.Email : existingEmployee.Email;
            existingEmployee.FirstName              = !string.IsNullOrWhiteSpace(request.FirstName) ? request.FirstName : existingEmployee.FirstName;
            existingEmployee.LastName               = !string.IsNullOrWhiteSpace(request.LastName) ? request.LastName : existingEmployee.LastName;
            existingEmployee.AppliedPromocodesCount = request.AppliedPromocodesCount != 0 ? request.AppliedPromocodesCount : existingEmployee.AppliedPromocodesCount;

            _employeeRepository.Update(existingEmployee);

            var employeeResponse = new EmployeeResponse
            {
                Id = existingEmployee.Id,
                FullName = existingEmployee.FullName,
                Email = existingEmployee.Email,
                Role = new RoleItemResponse()
                {
                    Name = existingEmployee.Role.Name,
                    Description = existingEmployee.Role.Description
                },
                AppliedPromocodesCount = existingEmployee.AppliedPromocodesCount
            };

            return Ok(employeeResponse);
        }
    }
}
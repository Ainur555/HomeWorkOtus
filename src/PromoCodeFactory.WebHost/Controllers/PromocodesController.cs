using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using PromoCodeFactory.WebHost.Models;
using PromoCodeFactory.WebHost.Models.PromoCodes;
using AutoMapper;
using PromoCodeFactory.WebHost.Services;
using PromoCodeFactory.WebHost.Services.PromoCodes;
using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.DataAccess.Contracts.PromoCodes;
using PromoCodeFactory.WebHost.Services.Preferences;

namespace PromoCodeFactory.WebHost.Controllers
{
    /// <summary>
    /// Промокоды
    /// </summary>
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PromocodesController : ControllerBase
    {
        private readonly IPromoCodeService _service;
        private readonly IMapper _mapper;


        public PromocodesController(IPromoCodeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка промокодов
        /// </summary>
        /// <param name="filterModel"><СustomerFilterModel/param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<ActionResult<PromoCodeModel>> GetCustomersAsync(PromoCodeFilterModel filterModel)
        {
            var filterDto = _mapper.Map<PromoCodeFilterModel, PromoCodeFilterDto>(filterModel);
            return Ok(_mapper.Map<List<CustomerModel>>(await _service.GetPagedAsync(filterDto)));
        }

        /// <summary>
        /// Создать промокод и выдать его клиентам с указанным предпочтением
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeRequest request)
        {
            await _service.GivePromoCodesToCustomersWithPreferenceAsync(_mapper.Map<GivePromoCodeRequestDto>(request));
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.DataAccess.Contracts.PromoCodes;
using PromoCodeFactory.WebHost.Models;
using PromoCodeFactory.WebHost.Models.PromoCodes;
using PromoCodeFactory.WebHost.Models.Request;
using PromoCodeFactory.WebHost.Models.Response;
using PromoCodeFactory.WebHost.Services.PromoCodes;

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
        /// <param name="request">PromoCodeFilterRequest</param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<ActionResult<PromoCodeResponse>> GetPromoCodesAsync(PromoCodeFilterRequest request)
        {
            var filterModel = _mapper.Map<PromoCodeFilterRequest, PromoCodeFilterModel>(request);
            return Ok(_mapper.Map<List<PromoCodeResponse>>(await _service.GetPagedAsync(filterModel, HttpContext.RequestAborted)));
        }

        /// <summary>
        /// Выдать промокод
        /// </summary>
        /// <param name="request">GivePromoCodeRequest</param>
        /// <returns></returns>
        [HttpPost]
        public Task GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeRequest request)
        {
            return _service.GivePromoCodesToCustomersWithPreferenceAsync(_mapper.Map<GivePromoCodeModel>(request), HttpContext.RequestAborted);
        }

        /// <summary>
        /// Получение всех промокодов
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllPromocodes")]
        public async Task<ActionResult<PromoCodeResponse>> GetAllAsync()
        {
            var promoCodes = await _service.GetAllAsync(HttpContext.RequestAborted);
            var response = _mapper.Map<List<PromoCodeResponse>>(promoCodes);
            return Ok(response);
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.WebHost.Models.Preferences;
using PromoCodeFactory.WebHost.Models.Request;
using PromoCodeFactory.WebHost.Models.Response;
using PromoCodeFactory.WebHost.Services.Preferences;

namespace PromoCodeFactory.WebHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferencesController : ControllerBase
    {
        private readonly IPreferenceService _service;
        private readonly IMapper _mapper;

        public PreferencesController(IPreferenceService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Получение списка предпочтений
        /// </summary>
        /// <param name="filterModel"><PreferencesFilterRequest/param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<ActionResult<PreferencesResponse>> GetPreferencesAsync(PreferencesFilterRequest request)
        {
            var filterModel = _mapper.Map<PreferencesFilterRequest, PreferencesFilterModel>(request);
            var response    = _mapper.Map<List<PreferencesResponse>>(await _service.GetPagedAsync(filterModel, HttpContext.RequestAborted));

            return Ok(response);
        }

        /// <summary>
        /// Получение всех предпочтений
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllPreferences")]
        public async Task<ActionResult<PreferencesResponse>> GetAllAsync()
        {
            var preferences = await _service.GetAllAsync(HttpContext.RequestAborted);
            var response = _mapper.Map<List<PreferencesResponse>>(preferences);
            return Ok(response);
        }

    }
}

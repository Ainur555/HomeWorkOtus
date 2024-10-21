using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.WebHost.Models.Preferences;
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
        /// <param name="filterModel"><СustomerFilterModel/param>
        /// <returns></returns>
        [HttpPost("list")]
        public async Task<ActionResult<PreferencesModel>> GetCustomersAsync(PreferencesFilterModel filterModel)
        {
            var filterDto = _mapper.Map<PreferencesFilterModel, PreferencesFilterDto>(filterModel);
            var response = _mapper.Map<List<PreferencesModel>>(await _service.GetPagedAsync(filterDto, HttpContext.RequestAborted));
            return Ok(response);
        }

    }
}

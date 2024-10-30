using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.DataAccess.Repositories;
using PromoCodeFactory.WebHost.Models;
using PromoCodeFactory.WebHost.Models.Preferences;

namespace PromoCodeFactory.WebHost.Services.Preferences
{
    public class PreferenceService : IPreferenceService
    {
        private readonly IMapper _mapper;
        private readonly IPreferenceRepository _preferenceRepository;
        public PreferenceService(
            IMapper mapper,
            IPreferenceRepository preferenceRepository)
        {
            _mapper = mapper;
            _preferenceRepository = preferenceRepository;
        }

        public async Task<ICollection<Preference>> GetPagedAsync(PreferencesFilterModel filterModel, CancellationToken cancellationToken)
        {
            return await _preferenceRepository.GetPagedAsync(_mapper.Map<PreferencesFilterModel, PreferencesFilterDto>(filterModel), cancellationToken);
        }
    }
}

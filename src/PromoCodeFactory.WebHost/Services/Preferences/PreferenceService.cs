using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.DataAccess.Contracts.Preferences;
using PromoCodeFactory.DataAccess.Repositories;

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

        public async Task<ICollection<PreferencesDto>> GetPagedAsync(PreferencesFilterDto filterDto, CancellationToken cancellationToken)
        {
            ICollection<Preference> entities = await _preferenceRepository.GetPagedAsync(filterDto, cancellationToken);
            return _mapper.Map<ICollection<Preference>, ICollection<PreferencesDto>>(entities);
        }
    }
}

using AutoMapper;
using PromoCodeFactory.WebHost.Models.Preferences;
using PromoCodeFactory.DataAccess.Contracts;
using System.Linq;
using PromoCodeFactory.DataAccess.Contracts.Preferences;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;

namespace PromoCodeFactory.WebHost.Mapping
{
    public class PreferenceMappingsProfile : Profile
    {
        public PreferenceMappingsProfile()
        {
            CreateMap<Preference, PreferencesDto>();
            CreateMap<PreferencesDto, PreferencesModel>();
            CreateMap<PreferencesFilterModel, PreferencesFilterDto>();
        }
      
    }
}

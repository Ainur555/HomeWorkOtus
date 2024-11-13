using AutoMapper;
using PromoCodeFactory.WebHost.Models.Preferences;
using PromoCodeFactory.DataAccess.Contracts;
using System.Linq;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models.Response;
using PromoCodeFactory.WebHost.Models.Request;
using PromoCodeFactory.WebHost.Models;

namespace PromoCodeFactory.WebHost.Mapping
{
    public class PreferenceMappingsProfile : Profile
    {
        public PreferenceMappingsProfile()
        {
            CreateMap<Preference, PreferencesResponse>();
            CreateMap<Preference, PreferencesModel>();
            CreateMap<PreferencesFilterRequest, PreferencesFilterModel>();
            CreateMap<PreferencesFilterModel, PreferencesFilterDto>();

            CreateMap<CustomerPreference, PreferencesResponse>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PreferenceId))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Preference.Name));
        }

    }
}

using AutoMapper;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts.Preferences;
using PromoCodeFactory.DataAccess.Contracts.Partners;
using PromoCodeFactory.WebHost.Models.Preferences;
using PromoCodeFactory.WebHost.Models.Partners;

namespace PromoCodeFactory.WebHost.Mapping
{
    public class PartnersMappingsProfile : Profile
    {
        public PartnersMappingsProfile() 
        {
            CreateMap<PartnerDto, PartnerModel>();         
        }
        
    }
}

using AutoMapper;
using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.DataAccess.Contracts.PromoCodes;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models.PromoCodes;
using PromoCodeFactory.WebHost.Models.Response;
using PromoCodeFactory.WebHost.Models.Request;

namespace PromoCodeFactory.WebHost.Mapping
{
    public class PromoCodeMappingsProfile : Profile
    {
        public PromoCodeMappingsProfile()
        {
            CreateMap<PromoCode, PromoCodeResponse>();
            CreateMap<PromoCode, PromoCodeShortResponse>();
            CreateMap<PromoCode, PromoCodeModel>();

            CreateMap<PromoCodeFilterRequest, PromoCodeFilterModel>();
            CreateMap<GivePromoCodeRequest, GivePromoCodeModel>();
        }
    }
}

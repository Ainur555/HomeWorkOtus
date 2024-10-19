using AutoMapper;
using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.DataAccess.Contracts.PromoCodes;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models.PromoCodes;

namespace PromoCodeFactory.WebHost.Mapping
{
    public class PromoCodeMappingsProfile : Profile
    {
        public PromoCodeMappingsProfile()
        {
            CreateMap<PromoCodeDto, PromoCodeModel>();
            CreateMap<PromoCode, PromoCodeDto>();
            CreateMap<PromoCodeShortResponseDto, PromoCodeShortResponse>();
            CreateMap<PromoCodeFilterDto, PromoCodeFilterModel>();
            CreateMap<GivePromoCodeRequest, GivePromoCodeRequestDto>();
        }
    }
}

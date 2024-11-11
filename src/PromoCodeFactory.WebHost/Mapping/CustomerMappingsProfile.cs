using AutoMapper;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.WebHost.Models;
using PromoCodeFactory.WebHost.Models.Request;
using PromoCodeFactory.WebHost.Models.Response;
using System.Linq;

namespace PromoCodeFactory.WebHost.Mapping
{
    /// <summary>
    /// Профиль автомаппера для маппинга клиентом
    /// </summary>
    public class CustomerMappingsProfile : Profile
    {
        public CustomerMappingsProfile()
        {
            CreateMap<CreateOrEditCustomerRequest, CreateOrEditCustomerModel>()
               .ForMember(dest => dest.PreferenceIds, opt => opt.MapFrom(src => src.PreferenceIds));

            CreateMap<СustomerFilterRequest, СustomerFilterModel>();
            CreateMap<СustomerFilterModel, CustomerFilterDto>();
            CreateMap<Customer, CustomerModel>();
            CreateMap<CreateOrEditCustomerModel, Customer>()
             .ForMember(c => c.Preferences, opt => opt.MapFrom((src, c) =>
                src.PreferenceIds.Select(prefId => new CustomerPreference
                {
                    PreferenceId = prefId,  
                    CustomerId = c.Id 
                })))
            .ForMember(c => c.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(c => c.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(c => c.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(c => c.PromoCodes, opt => opt.Ignore())
            .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<Customer, CustomerResponse>()
                  .ForMember(dest => dest.PromoCodes, opt => opt.MapFrom(src => src.PromoCodes));

            CreateMap<Customer, CustomerShortResponse>();


        }
    }
}

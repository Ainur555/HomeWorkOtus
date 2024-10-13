using AutoMapper;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.WebHost.Models;
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
            CreateMap<CustomerDto, CustomerModel>();
            CreateMap<CreateOrEditCustomerRequest, CreateOrEditCustomerRequestDto>()
               .ForMember(dest => dest.PreferenceIds, opt => opt.MapFrom(src => src.PreferenceIds));

            CreateMap<СustomerFilterModel, CustomerFilterDto>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<CreateOrEditCustomerRequestDto, Customer>()
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

            CreateMap<CustomerResponseDto, CustomerResponse>();
        }
    }
}

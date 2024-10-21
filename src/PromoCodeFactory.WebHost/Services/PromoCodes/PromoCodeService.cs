using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts.PromoCodes;
using PromoCodeFactory.DataAccess.Repositories;
using PromoCodeFactory.WebHost.Helpers;

namespace PromoCodeFactory.WebHost.Services.PromoCodes
{
    public class PromoCodeService : IPromoCodeService
    {
        private readonly IPromoCodeRepository _promocodeRepository;
        private readonly IPreferenceRepository _preferenceRepository;
        private readonly ICustomerPreferenceRepository _customerPreferenceRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public PromoCodeService(
            IPromoCodeRepository promocodeRepository,
            IPreferenceRepository preferenceRepository,
            IEmployeeRepository employeeRepository,
            ICustomerPreferenceRepository customerPreferenceRepository,
            IMapper mapper)
        {
            _promocodeRepository = promocodeRepository;
            _preferenceRepository = preferenceRepository;
            _employeeRepository = employeeRepository;
            _customerPreferenceRepository = customerPreferenceRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<PromoCodeDto>> GetPagedAsync(PromoCodeFilterDto filterDto, CancellationToken cancellationToken)
        {
            ICollection<PromoCode> entities = await _promocodeRepository.GetPagedAsync(filterDto, cancellationToken);
            return _mapper.Map<ICollection<PromoCode>, ICollection<PromoCodeDto>>(entities);
        }

        public async Task GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeRequestDto request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId, cancellationToken);
            var preference = await _preferenceRepository.GetByIdAsync(request.PreferenceId, cancellationToken);
            var customers = await _customerPreferenceRepository.GetCustomersByPreferenceAsync(request.PreferenceId, cancellationToken);

            foreach (var customer in customers)
            {
                await _promocodeRepository.AddAsync(new PromoCode
                {
                    ServiceInfo = request.ServiceInfo,
                    PartnerName = request.PartnerName,
                    Code = request.PromoCode,
                    BeginDate = request.BeginDate.ToDateTime(),
                    EndDate = request.EndDate.ToDateTime(),
                    Preference = preference,
                    PartnerManager = employee,
                    Customer = customer,
                }, cancellationToken);
            }

            await _promocodeRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
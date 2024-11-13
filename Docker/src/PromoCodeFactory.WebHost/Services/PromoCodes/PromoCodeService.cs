using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.DataAccess.Contracts.PromoCodes;
using PromoCodeFactory.DataAccess.Repositories;
using PromoCodeFactory.WebHost.Helpers;
using PromoCodeFactory.WebHost.Models;
using PromoCodeFactory.WebHost.Models.PromoCodes;

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

        public async Task<ICollection<PromoCode>> GetPagedAsync(PromoCodeFilterModel filterModel, CancellationToken cancellationToken)
        {
            return await _promocodeRepository.GetPagedAsync(_mapper.Map<PromoCodeFilterModel, PromoCodeFilterDto>(filterModel), cancellationToken); 
        }

        public async Task GivePromoCodesToCustomersWithPreferenceAsync(GivePromoCodeModel givePromoCodeModel, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(givePromoCodeModel.EmployeeId, cancellationToken);
            var preference = await _preferenceRepository.GetByIdAsync(givePromoCodeModel.PreferenceId, cancellationToken);
            var customers = await _customerPreferenceRepository.GetCustomersByPreferenceAsync(givePromoCodeModel.PreferenceId, cancellationToken);

            var tasks = customers.Select(async customer =>
            {
                var promoCode = new PromoCode
                {
                    ServiceInfo = givePromoCodeModel.ServiceInfo,
                    PartnerName = givePromoCodeModel.PartnerName,
                    Code = givePromoCodeModel.PromoCode,
                    BeginDate = givePromoCodeModel.BeginDate.ToDateTime(),
                    EndDate = givePromoCodeModel.EndDate.ToDateTime(),
                    PreferenceId = preference.Id,
                    EmployeeId = givePromoCodeModel.EmployeeId,
                    CustomerId = customer.Id,
                };
                await _promocodeRepository.AddAsync(promoCode, cancellationToken);
            });

            await Task.WhenAll(tasks);

            await _promocodeRepository.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<PromoCode>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _promocodeRepository.GetAllAsync(cancellationToken);
        }
    }
}
using EntityFrameWorkCore;
using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.DataAccess.Contracts.PromoCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public class PromoCodeRepository : EfRepository<PromoCode>, IPromoCodeRepository
    {
        public PromoCodeRepository(EfDbContext context) : base(context)
        {
        }

        public async Task<List<PromoCode>> GetByCustomerId(Guid customerId)
        {
            var allPromoCodes = await GetAllAsync(new CancellationToken());

            return allPromoCodes.Where(promoCode => promoCode.Customer != null && promoCode.Customer.Id == customerId).ToList();
        }

        public async Task<List<PromoCode>> GetPagedAsync(PromoCodeFilterDto filterDto)
        {
            var query = GetAll();

            if (!string.IsNullOrWhiteSpace(filterDto.PartnerName))
            {
                query = query.Where(c => c.PartnerName == filterDto.PartnerName);
            }

            if (!string.IsNullOrWhiteSpace(filterDto.ServiceInfo))
            {
                query = query.Where(c => c.ServiceInfo == filterDto.ServiceInfo);
            }

            if (!string.IsNullOrWhiteSpace(filterDto.Code))
            {
                query = query.Where(c => c.Code == filterDto.Code);
            }

            query = query
                .Skip((filterDto.Page - 1) * filterDto.ItemsPerPage)
                .Take(filterDto.ItemsPerPage);

            return await query.ToListAsync();
        }
    }
}

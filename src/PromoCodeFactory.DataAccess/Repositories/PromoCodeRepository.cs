using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameWorkCore;
using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts.PromoCodes;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public class PromoCodeRepository(EfDbContext context) : EfRepository<PromoCode>(context), IPromoCodeRepository
    {
        public async Task<List<PromoCode>> GetByCustomerId(Guid customerId, CancellationToken cancellationToken)
        {
            var allPromoCodes = await GetAllAsync(cancellationToken);

            return allPromoCodes.Where(promoCode => promoCode.Customer != null && promoCode.Customer.Id == customerId).ToList();
        }

        public Task<List<PromoCode>> GetPagedAsync(PromoCodeFilterDto filterDto, CancellationToken cancellationToken)
        {
            var query = GetAll();

            query = query.Where(c => c.PartnerName == filterDto.PartnerName);

            query = query.Where(c => c.ServiceInfo == filterDto.ServiceInfo);

            query = query.Where(c => c.Code == filterDto.Code);

            query = query
                .Skip((filterDto.Page - 1) * filterDto.ItemsPerPage)
                .Take(filterDto.ItemsPerPage);

            return query.ToListAsync(cancellationToken);
        }
    }
}
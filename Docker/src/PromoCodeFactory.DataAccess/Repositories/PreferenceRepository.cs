using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFrameWorkCore;
using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts;

namespace PromoCodeFactory.DataAccess.Repositories
{
    public class PreferenceRepository(EfDbContext context) : EfRepository<Preference>(context), IPreferenceRepository
    {
        public Task<List<Preference>> GetPagedAsync(PreferencesFilterDto filterDto, CancellationToken cancellationToken)
        {
            var query = GetAll();


            if (!string.IsNullOrWhiteSpace(filterDto.Name))
            {
                query = query.Where(c => c.Name == filterDto.Name);
            }

            query = query
                .Skip((filterDto.Page - 1) * filterDto.ItemsPerPage)
                .Take(filterDto.ItemsPerPage);

            return query.ToListAsync(cancellationToken: cancellationToken);
        }
    }
}

using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.DataAccess.Contracts.Preferences;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PromoCodeFactory.WebHost.Services.Preferences
{
    public interface IPreferenceService
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterDto"> ДТО фильтра. </param>
        /// <returns> Список предпочтений. </returns>
        Task<ICollection<PreferencesDto>> GetPagedAsync(PreferencesFilterDto filterDto);
    }
}

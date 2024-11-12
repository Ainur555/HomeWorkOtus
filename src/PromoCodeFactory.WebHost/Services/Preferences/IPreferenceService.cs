using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Contracts;
using PromoCodeFactory.WebHost.Models.Preferences;

namespace PromoCodeFactory.WebHost.Services.Preferences
{
    public interface IPreferenceService
    {
        /// <summary>
        /// Получить постраничный список.
        /// </summary>
        /// <param name="filterModel"> модель фильтра </param>
        /// <param name="cancellationToken"> токен отмена </param>
        /// <returns> Список предпочтений. </returns>
        Task<ICollection<Preference>> GetPagedAsync(PreferencesFilterModel filterModel, CancellationToken cancellationToken);

        /// <summary>
        /// Получить все предпочтения
        /// </summary>
        /// <param name="cancellationToken"> cancellationToken </param>
        /// <returns>Список предпочтений</returns>
        Task<List<Preference>> GetAllAsync(CancellationToken cancellationToken);
    }
}

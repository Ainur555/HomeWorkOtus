using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Contracts.Preferences
{
    public class PreferencesDto
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
    }
}

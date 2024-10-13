using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess.Contracts
{
    public class PreferencesFilterDto
    {
        public string Name { get; set; }

        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
    }
}

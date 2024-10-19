using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameWorkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace PromoCodeFactory.WebHost.Extensions
{
    public static class EntityFrameworkInstaller
    {
        public static IServiceCollection ConfigureContext(this IServiceCollection services,
        string connectionString)
        {
            services.AddDbContext<EfDbContext>(optionsBuilder
                => optionsBuilder
                    .UseSqlite(connectionString));

            return services;
        }
    }
}

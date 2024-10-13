using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromoCodeFactory.DataAccess.Repositories;
using PromoCodeFactory.WebHost.Services;
using PromoCodeFactory.WebHost.Settings;
using EntityFrameWorkCore;
using PromoCodeFactory.WebHost.Services.Preferences;

namespace PromoCodeFactory.WebHost
{
    public static class Registrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettings = configuration.Get<ApplicationSettings>();
            services.AddSingleton(applicationSettings)
                    .AddSingleton((IConfigurationRoot)configuration)
                    .InstallServices()
                    .ConfigureContext(applicationSettings.ConnectionString)
                    .InstallRepositories();
            return services;
        }

        private static IServiceCollection InstallServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<ICustomerService, CustomerService>()
                .AddTransient<IPreferenceService, PreferenceService>();
            return serviceCollection;
        }

        private static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<ICustomerRepository, CustomerRepository>()
                .AddTransient<IPreferenceRepository, PreferenceRepository>()
                .AddTransient<ICustomerPreferenceRepository, CustomerPreferenceRepository>()
                .AddTransient<IPromoCodeRepository, PromoCodeRepository>();
            return serviceCollection;
        }
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromoCodeFactory.DataAccess.Repositories;
using PromoCodeFactory.WebHost.Services;
using PromoCodeFactory.WebHost.Services.Preferences;
using PromoCodeFactory.WebHost.Services.PromoCodes;
using PromoCodeFactory.WebHost.Settings;

namespace PromoCodeFactory.WebHost
{
    public static class Registrar
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettings = configuration.Get<ApplicationSettings>();
            services.AddSingleton(applicationSettings)
                    .AddSingleton(configuration)
                    .InstallServices()
                    .InstallRepositories();
            return services;
        }

        private static IServiceCollection InstallServices(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<ICustomerService, CustomerService>()
                .AddTransient<IPreferenceService, PreferenceService>()
                .AddTransient<IPromoCodeService, PromoCodeService>();
            return serviceCollection;
        }

        private static IServiceCollection InstallRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<ICustomerRepository, CustomerRepository>()
                .AddTransient<IPreferenceRepository, PreferenceRepository>()
                .AddTransient<ICustomerPreferenceRepository, CustomerPreferenceRepository>()
                .AddTransient<IPromoCodeRepository, PromoCodeRepository>()
                .AddTransient<IEmployeeRepository, EmployeeRepository>();
            return serviceCollection;
        }
    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EntityFrameWorkCore;
using Microsoft.EntityFrameworkCore;
using PromoCodeFactory.DataAccess;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System;
using System.Runtime.InteropServices;
namespace PromoCodeFactory.WebHost.Extensions
{
    public static class HostExtensions
    {
        public static async Task MigrationDataBaseAcync(this IHost webHost)
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                using (var db = services.GetRequiredService<EfDbContext>())
                {
                    try
                    {
                        await db.Database.MigrateAsync();
                        DbInitializer.Initialize(db);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
        }
    }
}

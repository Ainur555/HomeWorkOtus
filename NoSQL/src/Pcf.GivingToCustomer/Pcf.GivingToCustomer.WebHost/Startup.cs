using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Pcf.GivingToCustomer.Core.Abstractions.Gateways;
using Pcf.GivingToCustomer.Core.Abstractions.Repositories;
using Pcf.GivingToCustomer.DataAccess;
using Pcf.GivingToCustomer.DataAccess.Data;
using Pcf.GivingToCustomer.DataAccess.Repositories;
using Pcf.GivingToCustomer.Integration;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;
using Pcf.GivingToCustomer.Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Pcf.GivingToCustomer.Core.Domain;

namespace Pcf.GivingToCustomer.WebHost
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddMvcOptions(x=> 
                x.SuppressAsyncSuffixInActionNames = false);
           // services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<INotificationGateway, NotificationGateway>();
            //services.AddScoped<IDbInitializer, EfDbInitializer>();

            services.Configure<MongoSettings>(Configuration.GetSection("MongoSettings"));


            services.AddSingleton<IMongoClient>(serviceProvider =>
            {
                var mongoSettings = serviceProvider.GetRequiredService<IOptions<MongoSettings>>().Value;
                return new MongoClient(mongoSettings.ConnectionString);
            });

            services.AddSingleton<DataContext>(serviceProvider =>
            {
                var mongoClient = serviceProvider.GetRequiredService<IMongoClient>();
                var mongoSettings = serviceProvider.GetRequiredService<IOptions<MongoSettings>>().Value;
                return new DataContext(mongoClient, mongoSettings.DatabaseName);
            });

            services.AddScoped<IRepository<Customer>>(serviceProvider =>
            {
                var context = serviceProvider.GetRequiredService<DataContext>();
                return new EfRepository<Customer>(context, "Customers");
            });

            services.AddScoped<IRepository<Preference>>(serviceProvider =>
            {
                var context = serviceProvider.GetRequiredService<DataContext>();
                return new EfRepository<Preference>(context, "Preferences");
            });

            services.AddScoped<IRepository<PromoCode>>(serviceProvider =>
            {
                var context = serviceProvider.GetRequiredService<DataContext>();
                return new EfRepository<PromoCode>(context, "PromoCodes");
            });

            //services.AddScoped<IRepository<Customer>, EfRepository<Customer>>();

            //services.AddDbContext<DataContext>(x =>
            //{
            //    x.UseNpgsql(Configuration.GetConnectionString("PromocodeFactoryGivingToCustomerDb"));
            //    x.UseSnakeCaseNamingConvention();
            //    x.UseLazyLoadingProxies();
            //});

            services.AddOpenApiDocument(options =>
            {
                options.Title = "PromoCode Factory Giving To Customer API Doc";
                options.Version = "1.0";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseOpenApi();
            app.UseSwaggerUi(x =>
            {
                x.DocExpansion = "list";
            });
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
            //dbInitializer.InitializeDb();
        }
    }
}
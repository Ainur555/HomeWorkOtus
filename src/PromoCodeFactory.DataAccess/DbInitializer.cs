using EntityFrameWorkCore;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromoCodeFactory.DataAccess
{
    public class DbInitializer
    {
        public static void Initialize(EfDbContext context)
        {
            context.Database.EnsureCreated();

            SeedRoles(context);
            SeedEmployess(context);
            SeedPreferences(context);
            SeedCustomers(context);
        }

        private static void SeedRoles(EfDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(FakeDataFactory.Roles);
                context.SaveChanges();
            }

        }

        private static void SeedEmployess(EfDbContext context)
        {
            if (!context.Employees.Any())
            {
                foreach (var employee in FakeDataFactory.Employees)
                {                 
                    var roleFromDb = context.Roles.FirstOrDefault(r => r.Name == employee.Role.Name);
                    if (roleFromDb != null)
                    {
                        employee.Role = roleFromDb;
                    }
                    context.Employees.Add(employee);
                }
                context.SaveChanges();
            }
        }

        private static void SeedPreferences(EfDbContext context)
        {
            if (!context.Preferences.Any())
            {
                context.Preferences.AddRange(FakeDataFactory.Preferences);
                context.SaveChanges();
            }
        }

        private static void SeedCustomers(EfDbContext context)
        {

            if (!context.Customers.Any())
            {
                foreach (var customer in FakeDataFactory.Customers)
                {
                    context.Customers.Add(customer);

                    foreach (var preference in customer.Preferences)
                    {
                        var existingPreference = context.Preferences.Find(preference.PreferenceId);

                        if (existingPreference != null)
                        {
                            preference.CustomerId = customer.Id;
                            context.Set<CustomerPreference>().Add(preference);
                        }
                    }
                }
                context.SaveChanges();
            }
        }
    }
}

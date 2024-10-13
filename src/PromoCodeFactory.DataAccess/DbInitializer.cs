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
            // Убедитесь, что база данных создана
            context.Database.EnsureCreated();

            // Загрузка ролей, если их нет
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(FakeDataFactory.Roles);
                context.SaveChanges();
            }

            // Загрузка сотрудников, если их нет
            if (!context.Employees.Any())
            {
                foreach (var employee in FakeDataFactory.Employees)
                {
                    // Поскольку в FakeDataFactory используется ссылка на Role (которая может быть null),
                    // мы должны заменить её на объект Role из базы данных
                    var roleFromDb = context.Roles.FirstOrDefault(r => r.Name == employee.Role.Name);
                    if (roleFromDb != null)
                    {
                        employee.Role = roleFromDb;
                    }
                    context.Employees.Add(employee);
                }
                context.SaveChanges();
            }

            // Загрузка предпочтений, если их нет
            if (!context.Preferences.Any())
            {
                context.Preferences.AddRange(FakeDataFactory.Preferences);
                context.SaveChanges();
            }

            if (!context.Customers.Any())
            {
                foreach (var customer in FakeDataFactory.Customers)
                {
                    // Добавляем клиента
                    context.Customers.Add(customer);

                    // Получаем предпочтения, которые будем связывать с клиентом
                    foreach (var preference in customer.Preferences)
                    {
                        // Убедимся, что Preference уже загружен в контекст
                        var existingPreference = context.Preferences.Find(preference.PreferenceId);
                        if (existingPreference != null)
                        {
                            // Установим CustomerId для CustomerPreference
                            preference.CustomerId = customer.Id;

                            // Добавляем CustomerPreference в контекст
                            context.Set<CustomerPreference>().Add(preference);
                        }
                    }
                }
                context.SaveChanges(); // Сохраняем изменения после добавления всех предпочтений
            }
        }
    }
}

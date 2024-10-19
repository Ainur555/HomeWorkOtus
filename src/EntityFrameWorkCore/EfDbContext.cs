using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.Core.Domain.Administration;

namespace EntityFrameWorkCore
{
    public class EfDbContext : DbContext
    {
        public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Preference> Preferences { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<CustomerPreference> CustomerPreferences { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PartnerPromoCodeLimit> PartnerPromoCodeLimits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Настройка Role
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(r => r.Name)
                .HasMaxLength(100)
                .IsRequired();
                entity
                    .Property(r => r.Description)
                    .HasMaxLength(250);
            });
                

            // Настройка Employee
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsRequired();
                entity
                    .Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsRequired();
                entity
                    .Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsRequired();
                entity
                    .HasOne(e => e.Role)
                    .WithMany()
                    .HasForeignKey(e => e.RoleId);

                entity
                    .HasMany(employee => employee.PromoCodes)
                    .WithOne(promocode => promocode.PartnerManager)
                    .HasForeignKey(promocode => promocode.EmployeeId);


            });

            // Настройка Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(c => c.FirstName)
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(c => c.LastName)
                .HasMaxLength(50)
                .IsRequired();

                entity.Property(c => c.Email)
                .HasMaxLength(50)
                .IsRequired();

                entity
                .HasMany(customer => customer.PromoCodes)
                .WithOne(promocode => promocode.Customer)
                .HasForeignKey(promocode => promocode.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            });


            // Настройка связи многие ко многим Customer и Preference через CustomerPreference
            modelBuilder.Entity<CustomerPreference>(entity =>
            {
                entity.HasKey(cp => new { cp.CustomerId, cp.PreferenceId });
                entity
                    .HasOne(cp => cp.Customer)
                    .WithMany(c => c.Preferences)
                    .HasForeignKey(cp => cp.CustomerId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity
                   .HasOne(cp => cp.Preference)
                   .WithMany()
                   .HasForeignKey(cp => cp.PreferenceId)
                   .OnDelete(DeleteBehavior.Restrict);
            });

            // Настройка PromoCode
            modelBuilder.Entity<PromoCode>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(p => p.Code)
                .HasMaxLength(20)
                .IsRequired();
                entity
                    .Property(p => p.ServiceInfo)
                    .HasMaxLength(250);
                entity
                     .Property(p => p.PartnerName)
                    .HasMaxLength(100);                             
            });

            modelBuilder.Entity<Preference>(entity =>
            {
                entity
                    .HasMany(preference => preference.Promocodes)
                    .WithOne(promocode => promocode.Preference)
                    .HasForeignKey(promocode => promocode.PreferenceId);

                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).HasColumnName("PreferenceId");
                entity.Property(x => x.Name).HasMaxLength(32);
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity
                    .HasMany(partner => partner.PartnerLimits)
                    .WithOne(partnerLimit => partnerLimit.Partner)
                    .HasForeignKey(partnerLimit => partnerLimit.PartnerId);

                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).HasColumnName("PartnerId");
                entity.Property(x => x.Name).HasMaxLength(32);
            });

            modelBuilder.Entity<PartnerPromoCodeLimit>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).HasColumnName("PartnerPromocodeLimitId");
                entity.Property(x => x.CancelDate).IsRequired(false);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

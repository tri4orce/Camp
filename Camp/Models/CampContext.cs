using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Camp.Models
{
    public class CampContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Order> Orders { get; set; }


        public CampContext(DbContextOptions<CampContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //string adminRoleName = "admin";

            //string adminEmail = "admin@gmail.com";
            //string adminPassword = "123456";

            //User adminUser = new User { UserId = 1, Email = adminEmail, Password = adminPassword };
            //Role adminRole = new Role { RoleId = 1, Name = adminRoleName };

            //adminUser.Roles.Add(adminRole);
            //adminRole.Users.Add(adminUser);

            //modelBuilder.Entity<Role>().HasData(new Role[] { adminRole });
            //modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
    }
}

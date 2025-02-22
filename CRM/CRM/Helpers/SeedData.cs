using DataLayer;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CRM.Helpers
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Context(
                serviceProvider.GetRequiredService<DbContextOptions<Context>>()))
            {
                // Eğer tabloda kullanıcı varsa ekleme yapma
                if (context.tbl_users.Any())
                {
                    return; // Zaten kullanıcı var
                }

                // Varsayılan admin kullanıcısı ekle
                var adminUser = new Users
                {
                    UserName = "admin",
                    Password = PasswordHelper.HashPassword("admin123"),
                    Email = "muratakgolll@hotmail.com",
                    Role = "Admin",
                    IsActive = true,
                    AdminApprove = true
                };

                context.tbl_users.Add(adminUser);
                context.SaveChanges();
            }
        }
    }
}

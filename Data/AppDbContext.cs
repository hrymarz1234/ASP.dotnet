
using System.Xml.Linq;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;




namespace Data
{

    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        
        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }
        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "contacts.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizationEntity>()
           .OwnsOne(e => e.Address);

            string ADMIN_ID = Guid.NewGuid().ToString();
            string ROLE_ID = Guid.NewGuid().ToString();

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "admin",
                NormalizedName = "ADMIN",
                Id = ROLE_ID,
                ConcurrencyStamp = ROLE_ID
            });
            var admin = new IdentityUser
            {
                Id = ADMIN_ID,
                Email = "adam@wsei.edu.pl",
                EmailConfirmed = true,
                UserName = "adam",
                NormalizedUserName = "ADMIN"
            };
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();
            admin.PasswordHash = ph.HashPassword(admin, "1234abcd!@#$ABCD");

            // zapisanie użytkownika
            modelBuilder.Entity<IdentityUser>().HasData(admin);

            // przypisanie roli administratora użytkownikowi
            modelBuilder.Entity<IdentityUserRole<string>>()
            .HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity() { Id = 1, Name = "Adam", Email = "adam@wsei.edu.pl", Phone = "127813268163", Birth = new DateTime(2000, 10, 10) },
                new ContactEntity() { Id = 2, Name = "Ewa", Email = "ewa@wsei.edu.pl", Phone = "293443823478", Birth = new DateTime(1999, 8, 10) }
            );
            modelBuilder.Entity<OrganizationEntity>().HasData(
         new OrganizationEntity()
         {
             Id = 1,
             Title = "WSEI",
             Nip = "83492384",
             Regon = "13424234",
         },
         new OrganizationEntity()
         {
             Id = 2,
             Title = "Firma",
             Nip = "2498534",
             Regon = "0873439249",
         }
     ); ;
            modelBuilder.Entity<ContactEntity>().HasData(
               new ContactEntity()
               {
                   Id = 1,
                   Name = "AA",
                   Email = "Adam",
                   Phone = "13424234",
                   OrganizationId = 1,

               },
               new ContactEntity()
               {
                   Id = 2,
                   Name = "C#",
                   Email = "Ewa",
                   Phone = "02879283",
                   OrganizationId = 2,
               }
           );
   

            modelBuilder.Entity<OrganizationEntity>()
               .OwnsOne(e => e.Address)
               .HasData(
                   new { OrganizationEntityId = 1, City = "Kraków", Street = "Św. Filipa 17", PostalCode = "31-150", Region = "małopolskie" },
                   new { OrganizationEntityId = 2, City = "Kraków", Street = "Krowoderska 45/6", PostalCode = "31-150", Region = "małopolskie" }
               );
        }
    }
}
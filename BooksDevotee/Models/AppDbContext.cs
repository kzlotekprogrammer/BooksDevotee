using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BooksDevotee.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly string AdminId = "E4F51172-01BD-4181-8619-920C75A1AC06";
        private string AdminRoleId = "AF67BA7A-070D-4382-A2F5-B70A628FD338";
        private string EmployeeRoleId = "50A16996-FE65-4508-BE89-5C1C332FB914";

        public DbSet<Book> Books { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketBook> BasketBooks { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>()
                .Property(b => b.BookId)
                .ValueGeneratedOnAdd();

            builder.Entity<Basket>()
                .Property(b => b.BasketId)
                .ValueGeneratedOnAdd();

            builder.Entity<Image>()
                .Property(i => i.ImageId)
                .ValueGeneratedOnAdd();

            builder.Entity<Category>()
                .Property(c => c.CategoryId)
                .ValueGeneratedOnAdd();

            builder.Entity<BookCategory>()
                .HasKey(bc => new { bc.BookId, bc.CategoryId });
            builder.Entity<BookCategory>()
                .HasOne(bc => bc.Book)
                .WithMany(b => b.BookCategories)
                .HasForeignKey(bc => bc.BookId);
            builder.Entity<BookCategory>()
                .HasOne(bc => bc.Category)
                .WithMany(c => c.BookCategories)
                .HasForeignKey(bc => bc.CategoryId);

            builder.Entity<BasketBook>()
                .HasKey(bb => new { bb.BookId, bb.BasketId });
            builder.Entity<BasketBook>()
                .HasOne(bb => bb.Book)
                .WithMany(b => b.BasketBooks)
                .HasForeignKey(bb => bb.BookId);
            builder.Entity<BasketBook>()
                .HasOne(bb => bb.Basket)
                .WithMany(b => b.BasketBooks)
                .HasForeignKey(bb => bb.BasketId);

            SeedCategories(builder);
            SeedUsers(builder);
            SeedRoles(builder);
            SeedUserRoles(builder);
        }

        private void SeedCategories(ModelBuilder builder)
        {
            builder.Entity<Category>().HasData(
            new Category()
            {
                CategoryId = 1,
                CategoryName = "Literatura obyczajowa, romans"
            },
            new Category()
            {
                CategoryId = 2,
                CategoryName = "Kryminał, sensacja, thriller"
            },
            new Category()
            {
                CategoryId = 3,
                CategoryName = "Fantasy, science fiction"
            },
            new Category()
            {
                CategoryId = 4,
                CategoryName = "Reportaż"
            },
            new Category()
            {
                CategoryId = 5,
                CategoryName = "Horror"
            },
            new Category()
            {
                CategoryId = 6,
                CategoryName = "Literatura młodzieżowa"
            });
        }

        private void SeedUsers(ModelBuilder builder)
        {
            ApplicationUser user = new ApplicationUser()
            {
                Id = AdminId,
                FirstName = "Admin",
                LastName = "Admin",
                UserName = "Admin@BooksDevotee.com",
                NormalizedUserName = "ADMIN@BOOKSDEVOTEE.COM",
                Email = "Admin@BooksDevotee.com",
                NormalizedEmail = "ADMIN@BOOKSDEVOTEE.COM",
                PhoneNumber = "123456789",
                Country = "Polska",
                City = "Warszawa",
                PostalCode = "11-111",
                StreetAndNumber = "BooksDevotee 1"
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin123!");

            builder.Entity<ApplicationUser>().HasData(user);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = AdminRoleId,
                    Name = "Admin",
                    ConcurrencyStamp = "1",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole()
                {
                    Id = EmployeeRoleId,
                    Name = "Employee",
                    ConcurrencyStamp = "2",
                    NormalizedName = "EMPLOYEE"
                });
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() 
                { 
                    RoleId = AdminRoleId, 
                    UserId = AdminId 
                });
        }
    }
}

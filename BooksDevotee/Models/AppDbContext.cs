using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksDevotee.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
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
    }
}

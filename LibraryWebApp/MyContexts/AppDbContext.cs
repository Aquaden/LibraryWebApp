using LibraryWebApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp.MyContexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Books> Books { get; set; }
       public  DbSet<Authors> Authors { get; set; }
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Personal> Personals { get; set; }
        public DbSet<BuyBook> BuyBooks { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Books>()
                .HasOne(o => o.Author)
                .WithMany(o => o.Books)
                .HasForeignKey(o => o.AuthorId);

            modelBuilder.Entity<Books>()
                .HasOne(o => o.Genre)
                .WithMany(o => o.Books)
                .HasForeignKey(o => o.GenreId);

            modelBuilder.Entity<BuyBook>()
                .HasOne(dp => dp.Book)
                .WithMany(d => d.BuyBook)
            .HasForeignKey(dp => dp.BookId);

            modelBuilder.Entity<BuyBook>()
                .HasOne(dp => dp.Personal)
                .WithMany(p => p.BuyBook)
                .HasForeignKey(dp => dp.PersonalId);


        }

    }
}

using LibraryMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
  
namespace LibraryMS.Data
{
    public class AppIdentityDbContext : IdentityDbContext<Account>
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<LibraryCard> LibraryCard { get; set; }
        public DbSet<BookItem> BookItem { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<BookReservation> BookReservation { get; set; }
        public DbSet<Book> Book { get; set; }



        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options): base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Account>()
                .HasOne(e => e.Person)
                .WithOne(e => e.Account)
                .HasForeignKey<Account>(e => e.PersonId);


            builder.Entity<Account>()
                .HasOne(e => e.LibraryCard)
                .WithOne(e => e.Account)
                .HasForeignKey<Account>(e => e.LibraryCardId);

            builder.Entity<Person>()
                .HasOne(e => e.Address)
                .WithOne(e => e.Person)
                .HasForeignKey<Person>(e => e.AddressId);

            


        }

    }
}

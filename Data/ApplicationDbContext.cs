#nullable disable

using Microsoft.EntityFrameworkCore;
using myClientListApp.Models;

namespace myClientListApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // model relationships, constraints, etc.

            modelBuilder.Entity<Client>()
                .HasMany(c => c.PhoneNumbers)
                .WithOne(p => p.Client)
                .HasForeignKey(p => p.ClientId);
        }
    }

}
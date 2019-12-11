using DataModel.Entities;
using Microsoft.EntityFrameworkCore;

namespace DbContext
{
    public class PhoneBookDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public virtual DbSet<Contact> Contacts { get; set; }

        public PhoneBookDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(contact => contact.ContactId);

                entity.HasIndex(contact => contact.PhoneNumber).IsUnique(true);
            });
        }
    }
}

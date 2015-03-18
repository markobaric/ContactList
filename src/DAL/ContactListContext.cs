using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Entities;

namespace DAL
{
    /// <summary>
    /// DbContext for database access
    /// </summary>
    public class ContactListContext : DbContext
    {
        private const string CONN_STRING_NAME = "ContactListConnString";

        public ContactListContext()
            : base(CONN_STRING_NAME)
        {
            // Default initialization
            Database.SetInitializer<ContactListContext>(new CreateDatabaseIfNotExists<ContactListContext>());

            // Seed data on initialization
            Database.SetInitializer<ContactListContext>(new CustomDbInitializer());
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<EntryType> EntryTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure cascade delete when deleting Contact
            //modelBuilder.Entity<Contact>().HasOptional(c => c.Emails).WithMany().HasForeignKey(c => c.Id).WillCascadeOnDelete(true);
            //modelBuilder.Entity<Contact>().HasOptional(c => c.Phones).WithMany().HasForeignKey(c => c.Id).WillCascadeOnDelete(true);
            //modelBuilder.Entity<Contact>().HasOptional(c => c.Tags).WithMany().HasForeignKey(c => c.Id).WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}

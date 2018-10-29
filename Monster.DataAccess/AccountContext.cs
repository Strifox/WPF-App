using Monster.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster.DataAccess
{
   public class AccountContext : DbContext
    {

        public AccountContext() : base("Accounts") { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var accountBuilder = modelBuilder.Entity<Account>();
            accountBuilder.ToTable("Users");
            accountBuilder.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            accountBuilder.Property(x => x.Username).IsRequired();
            accountBuilder.Property(x => x.PasswordHash).IsRequired();
            accountBuilder.Property(x => x.Salt).IsRequired();
            accountBuilder.Property(x => x.Firstname).IsRequired();
            accountBuilder.Property(x => x.Lastname).IsRequired();

            var noteBuilder = modelBuilder.Entity<Note>();
            noteBuilder.ToTable("Notes");
            noteBuilder.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            noteBuilder.Property(x => x.Title).IsRequired();
            noteBuilder.Property(x => x.Content).IsRequired();
        }
    }
}

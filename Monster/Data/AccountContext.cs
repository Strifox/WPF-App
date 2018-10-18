﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster
{
    class AccountContext : DbContext
    {

        public AccountContext() : base("Accounts") { }

        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var accountBuilder = modelBuilder.Entity<Account>();
            accountBuilder.ToTable("Users");
            accountBuilder.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            accountBuilder.Property(x => x.Username).IsRequired();
            accountBuilder.Property(x => x.PasswordHash).IsRequired();
            accountBuilder.Property(x => x.Salt).IsRequired();
        }
    }
}

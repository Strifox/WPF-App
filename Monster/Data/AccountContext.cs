using System;
using System.Collections.Generic;
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
            accountBuilder.HasKey(x => x.Id);
        }
    }
}

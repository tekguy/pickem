using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using Pickem.Model;

namespace Pickem.Data
{
    public class PickemContext:DbContext
    {
        public PickemContext() : base("PickemContext")
        {
            
        }

        public DbSet<NflLeague> Leagues { get; set; }
        public DbSet<NflTeam> Teams { get; set; }
        public DbSet<Week> Week { get; set; }
        public DbSet<Game> Schedule { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Configuration.LazyLoadingEnabled = true;

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });


            modelBuilder.ConfigNflTeam();
            modelBuilder.ConfigUserAccounts();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pickem.Model;

namespace Pickem.Data
{
    public static class EntityConfig
    {
        public static DbModelBuilder ConfigNflTeam(this DbModelBuilder modelBuilder)
        {
            var table = modelBuilder.Entity<NflTeam>();
            table.HasKey(n => new { n.Id });
            table.Property(m => m.Name).HasColumnType("varchar").HasMaxLength(40);
            
            return modelBuilder;
        }

        public static DbModelBuilder ConfigWeek(this DbModelBuilder modelBuilder)
        {
            var table = modelBuilder.Entity<Week>();

            table.HasKey(n => new { n.Id });
            table.Property(m => m.Name).HasColumnType("varchar").HasMaxLength(20);

            return modelBuilder;
        }

        public static DbModelBuilder ConfigGame(this DbModelBuilder modelBuilder)
        {
            var table = modelBuilder.Entity<Game>();

            table.HasKey(n => new { n.Id });

            modelBuilder.Entity<Game>().HasKey(m => m.HomeTeam);

            return modelBuilder;
        }

        public static DbModelBuilder ConfigUserAccounts(this DbModelBuilder modelBuilder)
        {
            var table = modelBuilder.Entity<UserAccount>();

            table.HasKey(n => new { n.Id });
            table.Property(m => m.EmailAddress).HasColumnType("varchar").HasMaxLength(120);
            table.Property(m => m.Password).HasColumnType("varchar").HasMaxLength(20);

            // ignore property
            modelBuilder.Entity<UserAccount>().Ignore(t => t.ConfirmPassword);

            return modelBuilder;
        }
    }
}

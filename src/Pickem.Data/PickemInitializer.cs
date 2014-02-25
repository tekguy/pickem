using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pickem.Model;

namespace Pickem.Data
{
    public class PickemInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PickemContext>
    {
        protected override void Seed(PickemContext context)
        {

            var leagues = new List<NflLeague>()
            {
                new NflLeague
                {
                    Name = "AFC",
                    Teams = new List<NflTeam>
                    {
                        new NflTeam {Name = "Buffalo Bills"},
                        new NflTeam {Name = "Miami Dolphins"},
                        new NflTeam {Name = "New England Patriots"},
                        new NflTeam {Name = "New York Jets"},
                    }
                }, new NflLeague
                {
                    Name = "NFC", 
                    Teams = new List<NflTeam>
                    {
                        new NflTeam {Name = "Dallas Cowgirls"},
                        new NflTeam {Name = "New York Vaginas"},
                        new NflTeam {Name = "Philadelphia E-A-G-L-E-S EAGLES!"},
                        new NflTeam {Name = "Washington Deadskins"},
                    }
                }
            };

            leagues.ForEach(s =>context.Leagues.Add(s));
            context.SaveChanges();

            // add weeks
            var weeks = new List<Week>();
            for (int i = 1; i < 17; i++)
            {
                weeks.Add(new Week{ Name = string.Format("Week {0}", i)});
            }

            weeks.ForEach(s => context.Week.Add(s));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}

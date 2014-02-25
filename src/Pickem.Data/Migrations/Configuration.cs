using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Pickem.Model;

namespace Pickem.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PickemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PickemContext context)
        {
            var leagues = new List<NflLeague>
            {
                new NflLeague
                {
                    Name = "AFC",
                    Teams = new List<NflTeam>
                    {
                        new NflTeam {Name = "Buffalo Bills", Codename = "Bills"},
                        new NflTeam {Name = "Miami Dolphins", Codename = "Dolphins"},
                        new NflTeam {Name = "New England Patriots", Codename = "Patriots"},
                        new NflTeam {Name = "New York Jets", Codename = "Jets"},
                    }
                },
                new NflLeague
                {
                    Name = "NFC",
                    Teams = new List<NflTeam>
                    {
                        new NflTeam {Name = "Dallas Cowgirls", Codename = "Cowboys"},
                        new NflTeam {Name = "New York Vaginas", Codename = "Giants"},
                        new NflTeam {Name = "Philadelphia E-A-G-L-E-S EAGLES!", Codename = "Eagles"},
                        new NflTeam {Name = "Washington Deadskins", Codename = "Redskins"},
                    }
                }
            };

            leagues.ForEach(s => context.Leagues.Add(s));
            context.SaveChanges();

            // add weeks
            var weeks = new List<Week>();
            DateTime startTime = DateTime.Now;
            DateTime endTime = DateTime.Now.AddDays(7);
            for (int i = 1; i < 17; i++)
            {
                startTime = startTime.AddDays(7);
                endTime = endTime.AddDays(7);
                weeks.Add(new Week
                {
                    Name = string.Format("Week {0}", i),
                    StartDate = startTime,
                    EndDate = endTime,
                    Games = new List<Game>
                    {
                        new Game
                        {
                            HomeTeam = context.Teams.Single(m=>m.Codename == "Eagles"), 
                            VisitorTeam = context.Teams.Single(m=>m.Codename == "Cowboys")
                        },
                        new Game
                        {
                            HomeTeam = context.Teams.Single(m=>m.Codename == "Redskins"),  
                            VisitorTeam = context.Teams.Single(m=>m.Codename == "Giants")
                        }
                    }
                });

                startTime.AddMonths(1);
            }

            weeks.ForEach(s => context.Week.Add(s));
            context.SaveChanges();

            // add user accounts
            var userAccounts = new List<UserAccount>();

            userAccounts.Add(new UserAccount { Name = "Gordon Durgha", EmailAddress = "gordon@mediariot.com", Password = "eagles", CreateDate = DateTime.Now });
            userAccounts.ForEach(m => context.UserAccounts.Add(m));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
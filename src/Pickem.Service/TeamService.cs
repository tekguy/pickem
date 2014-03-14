using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pickem.Data;
using Pickem.Model;
using Pickem.Service.Interface;

namespace Pickem.Service
{
    public class TeamService:ITeamService
    {
        public IEnumerable<NflTeam> NflTeams()
        {
            using (var db = new PickemContext())
            {
                return db.Teams.ToList();
            }
        }

        public NflTeam GetNflTeam(int teamId)
        {
            using (var db = new PickemContext())
            {
                return db.Teams.FirstOrDefault(m => m.Id == teamId);
            }
        }
    }
}

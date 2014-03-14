using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Pickem.Model;

namespace Pickem.Service.Interface
{
    public interface ITeamService
    {
        IEnumerable<NflTeam> NflTeams();
        NflTeam GetNflTeam(int teamId);
    }
}

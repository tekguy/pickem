using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickem.Model
{
    public class Game
    {
        public int Id { get; set; }
        public NflTeam HomeTeam { get; set; }
        public NflTeam VisitorTeam { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickem.Model
{
    public class NflLeague
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<NflTeam> Teams { get; set; }
    }
}

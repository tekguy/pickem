using System.Collections.Generic;

namespace Pickem.Model.ViewModel.Home
{
    public class BrowseTeamsViewModel:BaseViewModel
    {
        public IEnumerable<NflTeam> Teams { get; set; } 
    }
}
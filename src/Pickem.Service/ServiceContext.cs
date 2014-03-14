using Pickem.Service.Interface;

namespace Pickem.Service
{
    public class ServiceContext: IServiceContext
    {
        public IAccountService AccountService { get; set; }
        public ITeamService TeamService { get; set; }
        public IVoteService VoteService { get; set; }
        public ServiceContext(IVoteService voteService, IAccountService accountService, ITeamService teamService)
        {
            AccountService = accountService;
            TeamService = teamService;
            VoteService = voteService;
        }
    }
}

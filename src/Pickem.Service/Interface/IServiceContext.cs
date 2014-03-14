namespace Pickem.Service.Interface
{
    public interface IServiceContext
    {
        IAccountService AccountService { get; set; }
        IVoteService VoteService { get; set; }
        ITeamService TeamService { get; set; }
    }
}

using System;
using System.Web.Http;

namespace Pickem.Controllers.Api
{
    public class TeamController : BaseApiController
    {
        public IHttpActionResult Get()
        {
            try
            {
                var teams = ServiceContext.TeamService.NflTeams();
                return InternalServerError();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public IHttpActionResult Get(int id)
        {
            try
            {
                var team = ServiceContext.TeamService.GetNflTeam(id);
                return Ok(team);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
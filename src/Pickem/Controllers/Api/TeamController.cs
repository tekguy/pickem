using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Pickem.Model;
using Pickem.Service.Interface;

namespace Pickem.Controllers.Api
{
    public class TeamController : BaseApiController
    {
        // GET api/team
        public IHttpActionResult Get()
        {
            try
            {
                var teams = ServiceContext.TeamService.NflTeams();
                return Ok(teams);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        // GET api/team/5
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

        // POST api/team
        public void Post([FromBody] string value)
        {
        }

        // PUT api/team/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/team/5
        public void Delete(int id)
        {
        }
    }
}
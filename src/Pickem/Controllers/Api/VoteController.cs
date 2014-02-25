using System.Linq;
using System.Web.Http;
using Pickem.Model;

namespace Pickem.Controllers.Api
{
    public class VoteController : BaseApiController
    {
        
        [Route("api/vote/getweek")]
        // GET api/<controller>
        public Week GetWeek()
        {
            return GetActiveWeek();
        }


        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        private Week GetActiveWeek()
        {
            using (var db = DataSourceFactory.GetDbContext())
            {
                var week = db.Week.Include("Games").Include("Games.HomeTeam").Include("Games.VisitorTeam").FirstOrDefault();
                return week;
            }
        }
    }
}
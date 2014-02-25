using System.Web.Http;
using Microsoft.Practices.ServiceLocation;
using Pickem.Data;

namespace Pickem.Controllers.Api
{
    public class BaseApiController : ApiController
    {
        public BaseApiController()
        {
            DataSourceFactory = ServiceLocator.Current.GetInstance<IDataSourceFactory>();
        }
        public IDataSourceFactory DataSourceFactory { get; set; }
    }
}

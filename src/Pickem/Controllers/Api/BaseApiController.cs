using System;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.Practices.ServiceLocation;
using Pickem.Service.Interface;

namespace Pickem.Controllers.Api
{
    public class BaseApiController : ApiController
    {
        public IServiceContext ServiceContext { get { return ServiceLocator.Current.GetInstance<IServiceContext>(); } }
        public ExceptionResult HandleException(Exception ex)
        {
            //todo: log error
            return InternalServerError(ex);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using Pickem.Service.Interface;

namespace Pickem.Controllers
{
    public abstract partial class BaseController : Controller
    {
        public IServiceContext ServiceContext { get { return ServiceLocator.Current.GetInstance<IServiceContext>(); } }
	}
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pickem.Data;

namespace Pickem.Controllers
{
    public abstract partial class BaseController : Controller
    {
        public BaseController(IDataSourceFactory dataSourceFactory)
        {
            DataSourceFactory = dataSourceFactory;
        }
        public IDataSourceFactory DataSourceFactory { get; set; }
	}
}
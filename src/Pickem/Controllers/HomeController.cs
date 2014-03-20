using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pickem.Model;
using Pickem.Model.ViewModel.Home;
using Pickem.Service.Interface;

namespace Pickem.Controllers
{
    public partial class HomeController : Controller
    {
        /// <summary>
        /// The only MVC page needed!
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult Index()
        {
            return View();
        }

    }
}
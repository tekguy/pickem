using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pickem.Data;
using Pickem.Model;
using Pickem.Model.ViewModel.Home;

namespace Pickem.Controllers
{
    public partial class HomeController : BaseController
    {
        public HomeController(IDataSourceFactory dataSourceFactory) : base(dataSourceFactory)
        {
        }

        public virtual ActionResult Index()
        {
            return View();
        }


        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public virtual ActionResult Teams()
        {
            var model = new BrowseTeamsViewModel();
            using (var db = DataSourceFactory.GetDbContext())
            {
                model.Teams = db.Teams.ToList();
            }
            return View(model);
        }

        //public ActionResult Vote()
        //{
        //    var model = new VoteViewModel();
        //    using (var db = DataSourceFactory.GetDbContext())
        //    {
        //        model.GameWeek = GetActiveWeek();
        //    }
        //    return View(model);
        //}

    }
}
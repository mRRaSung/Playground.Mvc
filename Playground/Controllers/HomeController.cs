using Playground.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Playground.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult LINQ()
        {
            IList<LINQViewModel> result = new List<LINQViewModel>
            {
                new LINQViewModel{Id = 0, UserName = "AAA", Price = 15000, CreateTime = DateTime.Now },
                new LINQViewModel{Id = 1, UserName = "BBB", Price = 25000, CreateTime = DateTime.Now.AddDays(1) },
                new LINQViewModel{Id = 2, UserName = "CCC", Price = 35000, CreateTime = DateTime.Now.AddDays(2) },
            };

            //result = result.Where(x => x.Id == 1).ToList();


            return View(result);
        }
    }
}
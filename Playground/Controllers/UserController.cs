using Playground.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Playground.Controllers
{
    public class UserController : Controller
    {
        [Route("~/{type:int}")]
        public ActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logon(LoginViewModel model)
        {
            if(model.Account == "ryan" && model.Password == "123456")
                model.Message = "Success :D";

            return View(model);
        }
    }
}
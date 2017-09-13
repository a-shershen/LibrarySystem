using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySestem.WEB.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {      
        public ActionResult ControlPanel()
        {
            return View();
        }
    }
}
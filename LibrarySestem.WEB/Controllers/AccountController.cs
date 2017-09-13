using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibrarySestem.WEB.Controllers
{
    public class AccountController : Controller
    {
        private BLL.Interfaces.IAccountService accountService;

        public AccountController(BLL.Interfaces.IAccountService iAccountService)
        {
            accountService = iAccountService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (accountService.IsPasswordTrue(model.Login, model.Password))
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(model.Login, false);

                    return RedirectToAction("ControlPanel", "Admin");
                }

                else
                {
                    ViewBag.WrongPassword = true;

                    return View(model);
                }
            }

            else
            {
                return View(model);
            }
        }

        public ActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}
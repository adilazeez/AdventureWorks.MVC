using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdventureWorks.App.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewProfile()
        {
            return View();
        }

        public ActionResult RegisterNew()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string _userName)
        {
            Session["CurrentUserName"] = _userName;
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Logout()
        {
            return View();
        }
    }
}
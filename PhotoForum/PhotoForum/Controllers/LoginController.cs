using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhotoForum.Service.ActionService;
using System.Web.Mvc;
using System.Web.Security;

namespace PhotoForum.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult LoginConfirm(string username, string password)
        {
            AccessService access = new AccessService();
            if (access.login(username, password))
            {
                Session["User"] = username;
                if (access.checkAdmin(username))
                {
                    Session["Role"] = "ADMIN";
                }
                else
                {
                    Session["Role"] = "MEMBER";
                }
                return RedirectToAction("Index", "Home");
            } else 
            return RedirectToAction("Index", "Login");
        }
    }
}
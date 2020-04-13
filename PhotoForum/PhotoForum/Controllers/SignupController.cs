using System;
using PhotoForum.Models.DB;
using PhotoForum.Service.ModelService;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoForum.Controllers
{
    public class SignupController : Controller
    {
        // GET: Signup
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Signup(PHOTO_USER user)
        {
            UserService userService = new UserService();
            user.IMG = "user.png";
            user.STATUS = true;
            if (userService.create(user))
            {
                return RedirectToAction("Index","Login");
            }
            return RedirectToAction("Index", "Signup");
        }
    }
}
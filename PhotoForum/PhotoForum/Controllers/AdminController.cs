using PhotoForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoForum.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            //Response.Cookies["username"].Expires = DateTime.Now.AddDays(-1);
            return View();
        }
    }
}
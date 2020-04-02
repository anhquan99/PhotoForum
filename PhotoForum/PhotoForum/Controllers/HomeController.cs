using PhotoForum.Models.DB;
using PhotoForum.Service;
using PhotoForum.Service.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoForum.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.data = new Service.ActionService.UploadService().unDoUpload("Going-to-Space-is-my-only-Childhood-Dream-still-Alive-.jpg");
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}

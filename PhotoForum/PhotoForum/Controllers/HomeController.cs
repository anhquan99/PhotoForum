using PhotoForum.Models.DB;
using PhotoForum.Service;
using PhotoForum.Service.ActionService;
using PhotoForum.Service.ModelService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoForum.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           

            //ViewBag.Title = "Home Page";

            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            IMG img = new IMG()
            {
                USERNAME = "testCommand",
                STATUS = "public"
            };
            List<String> tags = new List<string>();
            tags.Add("tag1");
            tags.Add("tag5");

            Command.executeUploadImg(img, file, tags);
            return View();
        }
    }
}

using PhotoForum.Models.DB;
using PhotoForum.Service;
using PhotoForum.Service.ActionService;
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
            ViewBag.Title = "Home Page";

            return View();
        }
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            IMG img = new IMG()
            {
                IMG_NAME = file.FileName,
                UPLOAD_DATE = DateTime.Now,
                STATUS = "testStatus",
                USERNAME = "unitTest"
            };
            List<String> tags = new List<string>();
            tags.Add("tag1");
            tags.Add("tag3");
            tags.Add("tag4");
            ViewBag.data = Command.executeUploadImg(img, file,tags);
            return View();
        }
    }
}

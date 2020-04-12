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
            PhotoService photoService = new PhotoService();
            ViewBag.PhotoList = photoService.findAllPublic();
            return View();
        }

        [HttpGet]
        public ActionResult search(String tag)
        {
            PhotoService photoService = new PhotoService();
            ViewBag.PhotoList = photoService.findByTag(tag);
            return View();
        }
        
    }
}

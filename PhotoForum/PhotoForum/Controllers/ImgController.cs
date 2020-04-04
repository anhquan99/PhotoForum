using PhotoForum.Models.DB;
using PhotoForum.Service.ModelService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoForum.Controllers
{
    public class ImgController : Controller
    {
        // GET: Img
        public ActionResult Index()
        {
            ViewBag.data = Session["username"];
            return View();
        }
    }
}
using Forum.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            APIService service = new APIService();
            //ViewBag.data = service.loginWithFormAsync("unitTest", "updated").Result;
            //ViewBag.data = service.loginWithSessionAsync("unitTest";
            //ViewBag.data = service.linkAcouuntAsync("unitTest", "123");
            //ViewBag.data = service.get_photoAsync(9);\
            //ViewBag.data = service.getAllPhoto("unitTest");
            //ViewBag.data = service.getPhotoByTag("unitTest","tag1");
            //List<String> data = TextService.parseStringToListString(service.getPhotoByTag("unitTest", "tag1"));
            return View();
        }

        public ActionResult About(String username, String password)
        {

            ViewBag.username = username;
            ViewBag.password = password;
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
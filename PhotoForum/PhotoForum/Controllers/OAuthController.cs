using PhotoForum.Service.ActionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PhotoForum.Controllers
{
    public class OAuthController : Controller
    {
        // GET: OAuth
        public ActionResult Index(String url)
        {
            ViewBag.url = url;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username, string password, string url)
        {
            AccessService access = new AccessService();
            if (access.login(username, password))
            {
                Session["User"] = username;
                HttpCookie cookie = new HttpCookie("PhotoUsername", username);
                Response.SetCookie(cookie);
                if (access.checkAdmin(username))
                {
                    Session["Role"] = "ADMIN";
                }
                else
                {
                    Session["Role"] = "MEMBER";
                }
                FormsAuthentication.SetAuthCookie(username, true);
                return Redirect(url);
            }
            else
            {
                ViewBag.url = url;
                return View();
            }
               
            
        }
    }
}
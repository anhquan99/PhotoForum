using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Models;
using Forum.Service.ModelService;
using Forum.Service;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Forum.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

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
                FormsAuthentication.SetAuthCookie(username, true);
                return RedirectToAction("Index", "Home");
            }
            else
                return RedirectToAction("Login", "Authentication");
        }
        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult SignupConfirm(FORUM_USER user)
        {
            UserService userService = new UserService();
            user.ROLE = "MEMBER";
            if (userService.create(user))
            {
                return RedirectToAction("Login", "Authentication");
            }
            return RedirectToAction("Singup", "Authentication");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult LoginWithPhoto()
        {
            try
            {
                APIService service = new APIService();
                String cookie = service.loginWithCookie();
                cookie = TextService.parseCookie(cookie);
                HttpCookie savedCookie = HttpContext.Request.Cookies.Get(cookie);
                //if cookie exits
                if (savedCookie != null)
                {
                    LinkedUserService linkService = new LinkedUserService();
                    LINKED_USER user = linkService.findByLinkedName(savedCookie.Value);
                    if (user != null)
                    {
                        UserService userService = new UserService();
                        FORUM_USER forumUser = userService.findById(user.USERNAME);
                        Session["User"] = forumUser.USERNAME;
                        AccessService access = new AccessService();
                        if (access.checkAdmin(forumUser.USERNAME))
                        {
                            Session["Role"] = "ADMIN";
                        }
                        else
                        {
                            Session["Role"] = "MEMBER";
                        }
                        FormsAuthentication.SetAuthCookie(forumUser.USERNAME, true);
                        return Redirect("~/Home");
                    }
                    else
                    {
                        return Redirect("~/Authentication/SignupWith");
                    }
                }
                //cookie is not set
                else
                {
                    return Redirect($"http://localhost:60986/OAuth/?url={HttpContext.Request.Url.AbsoluteUri}");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public ActionResult SignupWith()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignupWith(FORUM_USER user)
        {
            UserService userService = new UserService();
            user.ROLE = "MEMBER";
            if (userService.create(user))
            {
                LinkedUserService linkService = new LinkedUserService();
                APIService apiService = new APIService();
                String cookie = apiService.loginWithCookie();
                cookie = TextService.parseCookie(cookie);
                HttpCookie savedCookie = HttpContext.Request.Cookies.Get(cookie);
                LINKED_USER linkUser = new LINKED_USER()
                {
                    USERNAME = user.USERNAME,
                    LINKED_USERNAME = savedCookie.Value
                };
                linkService.create(linkUser);
                return RedirectToAction("Login", "Authentication");
            }
            return RedirectToAction("Singup", "Authentication");
        }
    }
}
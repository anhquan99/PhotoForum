using System;
using PhotoForum.Service.ModelService;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoForum.Controllers
{
    [Authorize(Roles ="ADMIN")]
    public class AdminController : Controller
    {
        // GET: Admin
        
        public ActionResult ShowImg()
        {
            PhotoService photoService = new PhotoService();
            ViewBag.PhotoList = photoService.findAll();
            return View();
        }

        public ActionResult ShowUser()
        {
            UserService userService = new UserService();
            ViewBag.UserList = userService.findAll();
            return View();
        }

        public ActionResult UpdateImg(string id)
        {
            PhotoService photoService = new PhotoService();
            TempData["Img"] = photoService.findById(id);
            return View();
        }

        public ActionResult UpdateImgDB(PhotoForum.Models.DB.IMG Img)
        {
            PhotoService photoService = new PhotoService();
            if (photoService.update(Img))
            {
                return RedirectToAction("ShowImg");
            }
            else return RedirectToAction("ShowImg");
        }

        public ActionResult UpdateUser(string username)
        {
            UserService userService = new UserService();
            TempData["User"] = userService.findById(username);
            return View();
        }

        public ActionResult UpdateUserDB(PhotoForum.Models.DB.PHOTO_USER User)
        {
            UserService userService = new UserService();
            if (userService.update(User))
            {
                return RedirectToAction("ShowUser");
            }
            else return RedirectToAction("ShowUser");
        }

        public ActionResult CreateUser(string error)
        {
            ViewBag.Error = error;
            return View();
        }

        public ActionResult CreateUserDB(PhotoForum.Models.DB.PHOTO_USER User)
        {
            UserService userService = new UserService();
            if (userService.findById(User.USERNAME) == null)
            {
                if (userService.create(User))
                {
                    return RedirectToAction("ShowUser");
                }
                else return RedirectToAction("CreateUser", new { error =  "There's something wrong. Please Create again"});
            } else return RedirectToAction("CreateUser", new { error = "Your Username has been taken." });
        }
    }
}
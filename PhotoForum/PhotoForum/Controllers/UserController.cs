using PhotoForum.Models.DB;
using PhotoForum.Service.ModelService;
using PhotoForum.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoForum.Controllers
{
    [Authorize(Roles ="MEMBER,ADMIN")]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Upload()
        {
            return View();
        }
        public ActionResult ShowImg()
        {
            PhotoService photoService = new PhotoService();
            string username = (String)Session["User"];
            ViewBag.PhotoList = photoService.findByUsername(username);
            return View();
        }

        public ActionResult UpdateUser(string username)
        {
            UserService userService = new UserService();
            TempData["User"] = userService.findById(username);
            return View();
        }

        [HttpPost]
        public ActionResult UpdateUser(PhotoForum.Models.DB.PHOTO_USER User, HttpPostedFileBase img)
        {
            UserService userService = new UserService();
            ViewBag.data = Command.executeUpdateUser(User, img);
            return View();
        }
        public ActionResult UpdateImg(string id)
        {
            PhotoService photoService = new PhotoService();
            TempData["Img"] = photoService.findById(id);            
            return View();
        }
        public ActionResult UpdateImgDB(PhotoForum.Models.DB.IMG img)
        {
            PhotoService photoService = new PhotoService();
            if (photoService.update(img))
            {
                return RedirectToAction("ShowImg");
            }
            else return RedirectToAction("ShowImg");
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase img, String tags)
        {
            IMG uploadImg = new IMG()
            {
                USERNAME = Session["User"].ToString(),
                STATUS = "PUBLIC"
            };
            List<String> listTags = TextService.textToTags(tags);
            ViewBag.data = Command.executeUploadImg(uploadImg, img, listTags);
            return View();
        }

        public ActionResult DeleteImg(string id)
        {
            PhotoService photoService = new PhotoService();
            if (photoService.deleteById(id))
            {
                return RedirectToAction("ShowImg");
            }
            else return RedirectToAction("ShowImg");
        }

    }
}
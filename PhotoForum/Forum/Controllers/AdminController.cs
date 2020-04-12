using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Forum.Service.ModelService;
using System.Web.Mvc;

namespace Forum.Controllers
{
    [Authorize(Roles ="ADMIN")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowPost()
        {
            PostService postService = new PostService();
            ViewBag.PostList = postService.findApproved();
            return View();
        }
        public ActionResult DeletePost(string id)
        {
            PostService postService = new PostService();
            if (postService.deleteById(id))
            {
                return RedirectToAction("ShowPost", "Admin");
            }
            else return RedirectToAction("ShowPost", "Admin");
        }

        public ActionResult ApprovePost()
        {
            PostService postService = new PostService();
            ViewBag.PostList = postService.findPending();
            return View();
        }
        public ActionResult Approve(string id)
        {
            PostService postService = new PostService();
            if (postService.ApproveById(id))
            {
                return RedirectToAction("ApprovePost", "Admin");
            }
            else return RedirectToAction("ApprovePost", "Admin");
           
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Service;
using Forum.Service.ModelService;
using System.Web;
using Forum.Models;
using System.Web.Mvc;

namespace Forum.Controllers
{
    [Authorize(Roles ="ADMIN,MEMBER")]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Post()
        {
            APIService aPIService = new APIService();
            LinkedUserService linkedUserService = new LinkedUserService();
            LINKED_USER user = linkedUserService.findById((string)Session["User"]);
            string linkImg = aPIService.getAllPhoto(user.LINKED_USERNAME);
            List<String> listImg = TextService.parseStringToListString(linkImg);
            ViewBag.list = listImg;
            return View();
        }
        public ActionResult PostDB(POST post)
        {
            PostService postService = new PostService();
            post.POST_TIME = DateTime.Now;
            post.STATUS = "PENDING";
            if (postService.create(post))
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Post", "User");
        }
        public ActionResult ShowPosts()
        {
            PostService postService = new PostService();
            string username = (String)Session["User"];
            ViewBag.PostList = postService.findByUsername(username);
            return View();
        }
        
        public ActionResult UpdatePost(string id)
        {
            PostService postService = new PostService();
            TempData["Post"] = postService.findById(id);
            return View();
        }
        public ActionResult UpdatePostDB(POST post)
        {
            PostService postService = new PostService();
            if (postService.update(post))
            {
                return RedirectToAction("ShowPosts");
            }
            else return RedirectToAction("ShowPosts");
        }
        public ActionResult DeletePost(string id)
        {
            PostService postService = new PostService();
            if (postService.deleteById(id))
            {
                return RedirectToAction("ShowPosts", "User");
            }
            else return RedirectToAction("ShowPosts", "User");
        }
        public ActionResult UpdateUser(string username)
        {
            UserService userService = new UserService();
            TempData["User"] = userService.findById(username);
            return View();
        }
        public ActionResult UpdateUserDB(FORUM_USER user)
        {
            UserService userService = new UserService();
            if (userService.update(user))
            {
                return RedirectToAction("ShowPosts", "User");
            }
            else return RedirectToAction("Index", "Home");
        }
        public ActionResult linkUser()
        {
            LinkedUserService service = new LinkedUserService();
            if (service.findById(Session["User"].ToString()) == null)
            {
                return View();
            }
            return Redirect("~/User/UpdateUser");
        }
        [HttpPost]
        public ActionResult linkUser(String username, String password)
        {
            APIService apiService = new APIService();
            Forum.Models.DTO.UserDTO dto = new Models.DTO.UserDTO()
            {
                username = username,
                password = password
            };
            if (apiService.linkAcouunt(dto))
            {
                LinkedUserService linkService = new LinkedUserService();
                linkService.create(new LINKED_USER()
                {
                    USERNAME = Session["User"].ToString(),
                    LINKED_USERNAME = username
                });
                return Redirect("~/User/UpdateUser");
            }
            ViewBag.data = "FAILED";
            return View();
        }
    }
}
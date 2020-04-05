using PhotoForum.Models;
using PhotoForum.Models.DB;
using PhotoForum.Models.DTO;
using PhotoForum.Service.ActionService;
using PhotoForum.Service.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace PhotoForum.Controllers.API
{
    [RoutePrefix("Photo")]
    public class ForumAPIController : ApiController
    {
        [Route("link_account")]
        [HttpPost]
        public bool linkAccount([FromBody] User user)
        {
            try
            {
                AccessService service = new AccessService();
                return service.login(user.username, user.password) ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
        [Route("get_all_img_by_username/{username}")]
        [HttpGet]
        public List<String> getAllImgByUsername([FromUri] String username)
        {
            try
            {
                PhotoService service = new PhotoService();
                List<String> list = new List<String>();
                foreach (var i in service.findByUsername(username))
                {
                    list.Add(Url.Content("~/img/index/" + i.IMG_ID));
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        [Route("get_photo/{id:int}")]
        [HttpGet]
        public String getPhoto(int id)
        {
            try
            {
                String url = Url.Content("~/img/index/" + id);
                return url;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        //[Route("login_with")]
        //[HttpPost]
        //public String loginWith([FromBody] User user)
        //{
        //    try
        //    {
        //        //String username = HttpContext.Current.Session["username"].ToString();
        //        //if (context.Session["username"] != null)
        //        //{
        //        //    return context.Session["username"].ToString();
        //        //}
        //        if(user.username != null)
        //        {
        //            return user.username;
        //        }
        //        return null;
                
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        return null;
        //    }
        //}
        [Route("login_with_form")]
        [HttpPost]
        //public String loginWithForm([FromBody] String username, [FromBody] String password)
        public String loginWithForm([FromBody] User user)
        {
            try
            {
                if (new AccessService().login(user.username, user.password)) return user.username;
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        [Route("get_photo_by_tag")]
        [HttpPost]
        public List<String> getPhotoByTagOfUser([FromBody] User user)
        {
            try
            {
                PhotoService service = new PhotoService();
                List<String> list = new List<String>();
                foreach (var i in service.findByTagAndUsername(user.tag, user.username))
                {
                    list.Add(Url.Content("~/img/index/" + i));
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

    }
}

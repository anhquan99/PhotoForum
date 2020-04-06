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
        public ActionResult Index(int id)
        {
            PhotoService service = new PhotoService();
            IMG img = service.findById(id.ToString());
            var dir = Server.MapPath("/img");
            var path = Path.Combine(dir, img.IMG_NAME);
            return base.File(path, "image");
        }
    }
}
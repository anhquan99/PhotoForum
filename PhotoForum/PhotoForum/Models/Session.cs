using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoForum.Models
{
    public static class Session
    {
        public static String get()
        {
            return HttpContext.Current.Session["username"] as string;
        }
    }
}
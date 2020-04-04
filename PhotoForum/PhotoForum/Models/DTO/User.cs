using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoForum.Models.DTO
{
    public class User
    {
        public String username { set; get; }
        public String password { set; get; }
        public String tag { set; get; }
    }
}
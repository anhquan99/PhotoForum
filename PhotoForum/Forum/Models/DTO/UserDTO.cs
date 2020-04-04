using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models.DTO
{
    public class UserDTO
    {
        public String username { get; set; }
        public String password { get; set; }
        public String tag { set; get; }
    }
}
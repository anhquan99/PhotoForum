using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoForum.CustomException
{
    public class ImgErrorException : Exception
    {
        public ImgErrorException()
        {
        }

        public ImgErrorException(string message)
            : base(message)
        {
        }

        public ImgErrorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

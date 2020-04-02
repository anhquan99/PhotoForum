using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoForum.CustomException
{
    public class ModelErrorException : Exception
    {
        public ModelErrorException()
        {
        }

        public ModelErrorException(string message)
            : base(message)
        {
        }

        public ModelErrorException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
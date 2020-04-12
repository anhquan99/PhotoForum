using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoForum.Service
{
    public class TextService
    {
        public static List<String> textToTags(String tags)
        {
            string[] words = tags.Split(' ');

            return words.ToList();
        }
    }
}
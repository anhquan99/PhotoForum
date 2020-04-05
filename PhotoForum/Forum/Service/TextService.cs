using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Forum.Service
{
    public class TextService
    {
        public static List<String> parseStringToListString(String text)
        {
            try
            {
                text = text.Trim('"');
                text = text.Trim('[');
                text = text.Trim(']');
                text = text.Trim();
                String[] array = text.Split(',');
                for(int i = 0; i < array.Count(); i++)
                {
                    array[i] = array[i].Trim('"');
                }
                return array.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static String parseStringToUrl(String text)
        {
            try
            {
                text = text.Trim('"');
                text = text.Trim('[');
                text = text.Trim(']');
                text = text.Trim();
                return text;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
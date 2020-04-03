using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PhotoForum.Service.ActionService
{
    public class UploadService
    {
        private static String desPath = AppDomain.CurrentDomain.BaseDirectory + @"img";
        /// <summary>
        /// upload to the project img folder
        /// </summary>
        /// <param name="uploadFile"></param>
        /// <returns></returns>
        public bool upload(HttpPostedFileBase uploadFile, String ImgName)
        {
            try
            {
                if (uploadFile.ContentLength > 1)
                {
                    String fileName = Path.GetFileName(uploadFile.FileName);
                    bool flag = Directory.Exists(desPath);
                    String path = Path.Combine(desPath, ImgName);
                    uploadFile.SaveAs(path);
                }
                return true;
            }
            catch (Exception)
            {

                //throw new CustomException.ImgErrorException("ERROR: UPLOAD IMG AT TIME " + DateTime.Now.ToString() + " AT " + this.GetType().Name + "IN " + System.Reflection.MethodBase.GetCurrentMethod().ToString());
                throw;
            }
        }
        /// <summary>
        /// undo the upload if upload failed
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool unDoUpload(String fileName)
        {
            try
            {
                String file = desPath + @"\"  + fileName;
                if (File.Exists(file))
                {
                    File.Delete(file);
                    return true;
                }
                else throw new CustomException.ImgErrorException("ERROR: IMG NOT EXIST AT TIME " + DateTime.Now.ToString() + " AT " + this.GetType().Name + "IN " + System.Reflection.MethodBase.GetCurrentMethod().ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
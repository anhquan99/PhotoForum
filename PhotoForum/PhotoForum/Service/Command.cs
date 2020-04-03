using PhotoForum.CustomException;
using PhotoForum.Models.DB;
using PhotoForum.Service.ActionService;
using PhotoForum.Service.ModelService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PhotoForum.Service
{
    /// <summary>
    /// handle all the dangerous function
    /// </summary>
    public class Command
    {
        private static String success = "SUCCESS";
        private static String failed = "FAILED";
        private static String dateTimeFormat = "yyyy-MM-ddTHH-mm-ss";
        /// <summary>
        /// handle upload img of the user avatar when register
        /// </summary>
        /// <param name="user"></param>
        /// <param name="file"></param>
        public static String executeRegister(PHOTO_USER user, HttpPostedFileBase file)
        {
            UserService userService = new UserService();
            UploadService uploadService = new UploadService();
            user.IMG = user.USERNAME + DateTime.Now.ToString(dateTimeFormat) + Path.GetExtension(file.FileName);
            try
            {
                uploadService.upload(file, user.IMG);
                userService.create(user);
                return success;
            }
            catch (ImgErrorException ex)
            {
                Console.WriteLine(ex.Message);
                return failed;
            }
            catch (ModelErrorException ex)
            {
                uploadService.unDoUpload(user.IMG);
                Console.WriteLine(ex.Message);
                return failed;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return failed;
            }
        }
        /// <summary>
        /// handle upload img
        /// </summary>
        /// <param name="img"></param>
        /// <param name="file"></param>
        public static String executeUploadImg(IMG img, HttpPostedFileBase file, List<String> tags)
        {
            PhotoService photoService = new PhotoService();
            UploadService uploadService = new UploadService();
            img.IMG_NAME = img.USERNAME + DateTime.Now.ToString(dateTimeFormat) + Path.GetExtension(file.FileName);
            img.UPLOAD_DATE = DateTime.Now;
            int newId = 0;
            try
            {
                
                //upload img
                uploadService.upload(file, img.IMG_NAME);
                //create img
                photoService.create(img);
                //get newest img
                img.IMG_ID = photoService.findNewestImgIdOfUser(img.USERNAME);
                newId = img.IMG_ID;
                //update tags
                photoService.updateTags(img, tags);
                return success;
            }
            catch (ImgErrorException ex)
            {
                Console.WriteLine(ex.Message);
                return failed;
            }
            catch (ModelErrorException ex)
            {
                uploadService.unDoUpload(img.IMG_NAME);
                Console.WriteLine(ex.Message);
                return failed;
            }
            catch(ExecutionEngineException ex)
            {
                uploadService.unDoUpload(img.IMG_NAME);
                photoService.deleteById(newId.ToString());
                Console.WriteLine(ex.Message);
                return failed;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return failed;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        public static String executeDeleteImg(IMG img)
        {
            PhotoService photoService = new PhotoService();
            UploadService uploadService = new UploadService();
            try
            {
                //tags?
                photoService.deleteById(img.IMG_ID.ToString());
                uploadService.unDoUpload(img.IMG_NAME);
                return success;
            }
            catch (ImgErrorException ex)
            {
                photoService.create(img);
                Console.WriteLine(ex.Message);
                return failed;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return failed;
            }
        }
    }
}
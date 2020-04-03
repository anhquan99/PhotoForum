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
        /// 
        /// đăng kí trong github
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
        /// 
        /// thêm ảnh trong github
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
        /// handle delete img when error happend and back up old img
        /// xóa hình trong github
        /// </summary>
        /// <param name="img"></param>
        public static String executeDeleteImg(int imgId)
        {
            PhotoService photoService = new PhotoService();
            UploadService uploadService = new UploadService();
            IMG img = photoService.findById(imgId.ToString());
            //get old tag if error happend
            List<String> oldTags = photoService.getTagFormImg(imgId);
            try
            {
                
                photoService.deleteById(imgId.ToString());
                uploadService.unDoUpload(img.IMG_NAME);
                return success;
            }
            catch (ImgErrorException ex)
            {
                photoService.create(img);
                int newId = photoService.findNewestImgIdOfUser(img.USERNAME);
                img = photoService.findById(img.IMG_ID.ToString());
                photoService.updateTags(img, oldTags);
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
        /// update img only for tags and status
        /// 
        /// update hình trong github
        /// </summary>
        /// <param name="img"></param>
        /// <param name="tags"></param>
        /// <returns></returns>
        public static String executeUpdateImg(IMG img, List<String> tags)
        {
            PhotoService photoService = new PhotoService();
            UploadService uploadService = new UploadService();
            try
            {

                photoService.update(img);
                photoService.updateTags(img, tags);
                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return failed;
            }
        }
        /// <summary>
        /// handle udpate img of the user avatar when udpate
        /// 
        /// update user trong github
        /// </summary>
        /// <param name="user"></param>
        /// <param name="file"></param>
        public static String executeUpdateUser(PHOTO_USER user, HttpPostedFileBase file)
        {
            UserService userService = new UserService();
            UploadService uploadService = new UploadService();
            user.IMG = user.USERNAME + DateTime.Now.ToString(dateTimeFormat) + Path.GetExtension(file.FileName);
            try
            {
                uploadService.upload(file, user.IMG);
                userService.update(user);
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

    }
}
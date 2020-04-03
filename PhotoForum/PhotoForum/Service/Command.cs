using PhotoForum.CustomException;
using PhotoForum.Models.DB;
using PhotoForum.Service.ActionService;
using PhotoForum.Service.ModelService;
using System;
using System.Collections.Generic;
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
        /// <summary>
        /// handle upload img of the user avatar when register
        /// </summary>
        /// <param name="user"></param>
        /// <param name="file"></param>
        public static String executeRegister(PHOTO_USER user, HttpPostedFileBase file)
        {
            UserService userService = new UserService();
            UploadService uploadService = new UploadService();
            try
            {
                uploadService.upload(file);
                userService.create(user);
                return success;
            }
            catch (ImgErrorException ex)
            {
                uploadService.unDoUpload(file.FileName);
                Console.WriteLine(ex.Message);
                return failed;
            }
            catch (ModelErrorException ex)
            {
                uploadService.unDoUpload(file.FileName);
                userService.deleteById(user.USERNAME);
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
            try
            {
                //upload img
                uploadService.upload(file);
                //create img
                photoService.create(img);
                //get newest img
                img.IMG_ID = photoService.findNewestImgOfUser(img.USERNAME);
                //update tags
                ? executeUpdateTags(img, tags) == failed : throw new ModelErrorException();
                return success;
            }
            catch (ImgErrorException ex)
            {
                uploadService.unDoUpload(file.FileName);
                Console.WriteLine(ex.Message);
                return failed;
            }
            catch (ModelErrorException ex)
            {
                uploadService.unDoUpload(file.FileName);
                photoService.deleteById(img.IMG_ID.ToString());
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
        }
        /// <summary>
        /// handel update img  tags if fail returm all img origin tags
        /// </summary>
        /// <param name="img"></param>
        /// <param name="tags">String list</param>
        public static String executeUpdateTags(IMG img,List<String> tags)
        {
            TagService tagService = new TagService();
            PhotoService photoService = new PhotoService();
            List<TAG> oldTags = img.TAGs.ToList();
            try
            {
                foreach(var i in img.TAGs)
                {
                    img.TAGs.Remove(i);
                }
                foreach(var i in tags)
                {
                    TAG tag = tagService.findById(i);
                    if(tag != null)
                    {
                        TAG newTag = new TAG()
                        {
                            TAG_NAME = i
                        };
                        tagService.create(newTag);
                        img.TAGs.Add(newTag);
                    }
                    else if (img.TAGs.Contains(tag)) continue;
                    else
                    {
                        img.TAGs.Add(tag);
                    }
                }
                photoService.update(img);
                return success;
            }
            //revert img tags
            catch (Exception ex)
            {
                foreach(var i in oldTags)
                {
                    img.TAGs.Add(i);
                }
                photoService.update(img);
                Console.WriteLine(ex.Message);
                return failed;
            }
        }
    }
}
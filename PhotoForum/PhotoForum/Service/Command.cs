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
        /// <summary>
        /// handle upload img of the user avatar when register
        /// </summary>
        /// <param name="user"></param>
        /// <param name="file"></param>
        public void executeRegister(PHOTO_USER user, HttpPostedFileBase file)
        {
            UserService userService = new UserService();
            UploadService uploadService = new UploadService();
            try
            {
                uploadService.upload(file);
                userService.create(user);
            }
            catch (ImgErrorException)
            {
                uploadService.unDoUpload(file.FileName);
                throw;
            }
            catch (ModelErrorException)
            {
                uploadService.unDoUpload(file.FileName);
                userService.deleteById(user.USERNAME);
                throw;
            }
        }
        /// <summary>
        /// handle upload img
        /// </summary>
        /// <param name="img"></param>
        /// <param name="file"></param>
        public void executeUploadImg(IMG img, HttpPostedFileBase file, List<String> list)
        {
            PhotoService photoService = new PhotoService();
            UploadService uploadService = new UploadService();
            try
            {
                uploadService.upload(file);
                photoService.create(img);
            }
            catch (ImgErrorException)
            {
                uploadService.unDoUpload(file.FileName);
                throw;
            }
            catch (ModelErrorException)
            {
                uploadService.unDoUpload(file.FileName);
                photoService.deleteById(img.IMG_ID.ToString());
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="img"></param>
        public void executeDeleteImg(IMG img)
        {
            PhotoService photoService = new PhotoService();
            UploadService uploadService = new UploadService();
            try
            {
                photoService.deleteById(img.IMG_ID.ToString());
                uploadService.unDoUpload(img.IMG_NAME);
            }
            catch (ImgErrorException)
            {
                photoService.create(img);
                throw;
            }
        }
        /// <summary>
        /// handel update img  tags if fail returm all img origin tags
        /// </summary>
        /// <param name="img"></param>
        /// <param name="tags">String list</param>
        public void executeUpdateTags(IMG img,List<String> tags)
        {
            TagService tagService = new TagService();
            PhotoService photoService = new PhotoService();
            List<TAG> list = img.TAGs.ToList();
            try
            {
                foreach(var i in tags)
                {
                    TAG tag = tagService.findById(i);
                    if(tag != null)
                    {
                        TAG newTag = new TAG()
                        {
                            TAG_NAME = "i"
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
            }
            //revert img tags
            catch (Exception)
            {
                foreach(var i in img.TAGs)
                {
                    if(list.Contains(i) == false)
                    {
                        img.TAGs.Remove(i);
                    }
                }
                photoService.update(img);
                throw;
            }
        }
    }
}
using Forum.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Service
{
    public class PhotoService
    {
        APIService api;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public List<String> getPhotoByTag(String username, String tag)
        {
            try
            {
                
                UserDTO user = new UserDTO()
                {
                    username = username,
                    tag = tag
                };
                return TextService.parseStringToListString(api.getPhotoByTag(user));
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<String> getAllPhoto(String username)
        {
            try
            {
                return TextService.parseStringToListString(api.getAllPhoto(username));
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public String getPhoto(int id)
        {
            try
            {
                return TextService.parseStringToUrl(api.getPhoto(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public PhotoService()
        {
            api = new APIService();
        }
    }
}
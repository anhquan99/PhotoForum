using PhotoForum.Models.DB;
using PhotoForum.Service.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoForum.Service.ActionService
{
    public class AccessService
    {
        UserService service;
        /// <summary>
        /// login service
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool login(String username, String password)
        {
            try
            {
                if (service.findByUsernameAndPassword(username, password) != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void logout()
        {
        }
        /// <summary>
        /// check if user is admin or not
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool checkAdmin(String username)
        {
            try
            {
                var user = service.findById(username);
                if (user.ROLE == "ADMIN") return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public AccessService()
        {
            service = new UserService();
        }
    }
}
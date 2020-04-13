using Forum.Service.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Forum.Models.DTO;

namespace Forum.Service
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
                if (service.findByUsernameAndPassword(username, password) != null) return true;
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public String loginWithSession()
        //{
        //    try
        //    {
        //        APIService api = new APIService();
        //        return api.loginWithSession();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        /// <summary>
        /// take form imfomation to login
        /// return true if user exist
        /// </summary>
        /// <param name="username">photo username</param>
        /// <param name="password">photo password</param>
        /// <returns></returns>
        public bool loginWithForm(String username, String password)
        {
            try
            {
                APIService api = new APIService();
                return api.loginWithForm(username, password);
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// call api to create linked user
        /// </summary>
        /// <param name="username">forum username</param>
        /// <param name="photoUSername">photo username</param>
        /// <param name="photoPassword">photo passwords</param>
        public bool linkUser(String username, String photoUSername, String photoPassword)
        {
            try
            {
                UserDTO user = new UserDTO()
                {
                    username = photoUSername,
                    password = photoPassword
                };
                APIService api = new APIService();
                if (api.linkAcouunt(user))
                {
                    LinkedUserService linkService = new LinkedUserService();
                    bool status = linkService.create(new Models.LINKED_USER()
                    {
                        USERNAME = username,
                        LINKED_USERNAME = user.username

                    });
                    return status;
                }
                return false;

            }
            catch (Exception)
            {

                throw;
            }
        }
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
using Forum.Models.DTO;
using Forum.Service.ModelService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public void linkUser(String username, UserDTO user)
        {
            try
            {
                APIService api = new APIService();
                if (api.linkAcouunt(user.username, user.password))
                {
                    LinkedUserService linkService = new LinkedUserService();
                    linkService.create(new Models.LINKED_USER()
                    {
                        USERNAME = username,
                        LINKED_USERNAME = user.username

                    });
                }
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
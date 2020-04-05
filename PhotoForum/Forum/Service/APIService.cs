using Forum.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
namespace Forum.Service
{
    public class APIService : Controller
    {
        //public String loginWithSession()
        //{
        //    try
        //    {
        //        using (HttpClient client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri(MvcApplication.APIUrl + "login_with");
        //            client.DefaultRequestHeaders.Accept.Clear();
        //            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //            var response = client.GetAsync("");
        //            response.Wait();
        //            var result = response.Result;
        //            if (result.IsSuccessStatusCode)
        //            {
        //                String myResult = result.Content.ReadAsStringAsync().Result;
        //                return myResult;
        //            }
        //            return null;


        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //public async System.Threading.Tasks.Task<bool> loginWithFormAsync(String username, String password)
        //{
        //    try
        //    {
        //        UserDTO user = new UserDTO()
        //        {
        //            username = username,
        //            password = password
        //        };
        //        var json = JsonConvert.SerializeObject(user);
        //        var data = new StringContent(json, Encoding.UTF8, "application/json");
        //        String url = MvcApplication.APIUrl + "login_with_form";
        //        using (var client = new HttpClient())
        //        {
        //            var response = await client.PostAsync(url, data);
        //            if (response.IsSuccessStatusCode)
        //            {
        //                String result = response.Content.ReadAsStringAsync().Result;
        //                return result != null ? true : false;
        //            }
        //            return false;
        //        }
                

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool loginWithForm(String username, String password)
        {
            try
            {
                UserDTO user = new UserDTO()
                {
                    username = username,
                    password = password
                };
                var json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                String url = MvcApplication.APIUrl + "login_with_form";
                using (var client = new HttpClient())
                {
                    var response = client.PostAsync(url, data);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        String result = response.Result.Content.ReadAsStringAsync().Result;
                        return result != null ? true : false;
                    }
                    return false;
                }


            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool linkAcouunt(UserDTO user)
        {
            try
            {
                var json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                String url = MvcApplication.APIUrl + "link_account";
                using (var client = new HttpClient())
                {
                    var response = client.PostAsync(url, data);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        String result = response.Result.Content.ReadAsStringAsync().Result;
                        return result == "true" ? true : false;
                    }
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// get photo by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public String getPhoto(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.APIUrl + "get_photo/" + id);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("");
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        String myResult = result.Content.ReadAsStringAsync().Result;
                        return myResult;
                    }
                    return null;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// get all photo of linked user
        /// </summary>
        /// <param name="username">photo username</param>
        /// <returns></returns>
        public String getAllPhoto(String username)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(MvcApplication.APIUrl + "get_all_img_by_username/" + username);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var response = client.GetAsync("");
                    response.Wait();
                    var result = response.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        String myResult = result.Content.ReadAsStringAsync().Result;
                        return myResult;
                    }
                    return null;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// get photo of linked user by tag
        /// </summary>
        /// <param name="username">photo username</param>
        /// <param name="tag">tag</param>
        /// <returns></returns>
        public String getPhotoByTag(UserDTO user)
        {
            try
            {
                var json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                String url = MvcApplication.APIUrl + "get_photo_by_tag";
                using (var client = new HttpClient())
                {
                    var response = client.PostAsync(url, data);
                    response.Wait();
                    if (response.Result.IsSuccessStatusCode)
                    {
                        String result = response.Result.Content.ReadAsStringAsync().Result;
                        return result;
                    }
                    return null;
                }
            }
            catch (Exception)
            {

                throw;

            }
        }
    }
}
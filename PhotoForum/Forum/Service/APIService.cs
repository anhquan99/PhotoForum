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
        //}
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
        public bool linkAcouunt(String username, String password)
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
        public List<String> getAllPhoto(String username)
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
                        return TextService.parseStringToListString(myResult);
                    }
                    return null;


                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<String> getPhotoByTag(String username, String tag)
        {
            try
            {
                UserDTO user = new UserDTO()
                {
                    username = username,
                    tag = tag
                };
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
                        return TextService.parseStringToListString(result);
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
using PhotoForum.CustomException;
using PhotoForum.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoForum.Service.ModelService
{
    public class UserService : IService<PHOTO_USER>
    {
        /// <summary>
        /// create user
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool create(PHOTO_USER t)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    db.PHOTO_USER.Add(t);
                    if (db.SaveChanges() == 0) throw new Exception();
                    return true;
                }
            }
            catch (Exception)
            {
                throw new ModelErrorException("ERROR: CREATING USER AT TIME " + DateTime.Now.ToString() + " AT " + this.GetType().Name + "IN " + System.Reflection.MethodBase.GetCurrentMethod().ToString()); ;
            }
        }
        /// <summary>
        /// delete user
        /// </summary>
        /// <param name="id">id is username</param>
        /// <returns></returns>
        public bool deleteById(String username)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    var selectedUser = (from p in db.PHOTO_USER
                                        where p.USERNAME == username
                                        select p).SingleOrDefault();

                    if (selectedUser != null)
                    {
                        db.PHOTO_USER.Remove(selectedUser);
                        if (db.SaveChanges() == 0) throw new Exception();
                    }
                    else throw new ModelErrorException("ERROR: USER NOT FOUND");
                    return true;
                }
            }
            catch (Exception)
            {
                throw new ModelErrorException("ERROR: DELETING USER AT TIME " + DateTime.Now.ToString() + " AT " + this.GetType().Name + "IN " + System.Reflection.MethodBase.GetCurrentMethod().ToString());
            }
        }
        /// <summary>
        /// find all user
        /// </summary>
        /// <returns></returns>
        public List<PHOTO_USER> findAll()
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    return (from p in db.PHOTO_USER select p).ToList();
                }
            }
            catch (Exception)
            {
                throw new ModelErrorException("ERROR: READING USER AT TIME " + DateTime.Now.ToString() + " AT " + this.GetType().Name + "IN " + System.Reflection.MethodBase.GetCurrentMethod().ToString());
            }
        }
        /// <summary>
        /// find user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PHOTO_USER findById(String username)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    var selectedUser = (from p in db.PHOTO_USER
                                        where p.USERNAME == username
                                        select p).SingleOrDefault();

                    return selectedUser;
                }
            }
            catch (Exception)
            {
                throw new ModelErrorException();
            }
        }
        /// <summary>
        /// update user
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool update(PHOTO_USER t)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    var selectedUser = (from p in db.PHOTO_USER
                                        where p.USERNAME == t.USERNAME
                                        select p).SingleOrDefault();

                    if (selectedUser != null)
                    {
                        selectedUser.PASSWORD = t.PASSWORD;
                        selectedUser.IMG = t.IMG;
                        selectedUser.EMAIL = t.EMAIL;
                        selectedUser.ROLE = t.ROLE;
                        if (db.SaveChanges() == 0) throw new Exception();
                    }
                    else throw new ModelErrorException("ERROR: USER NOT FOUND");
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ModelErrorException("ERROR: DELETING USER AT TIME " + DateTime.Now.ToString() + " AT " + this.GetType().Name + "IN " + System.Reflection.MethodBase.GetCurrentMethod().ToString());
            }
        }
        /// <summary>
        /// login
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public PHOTO_USER findByUsernameAndPassword(String username, String password)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    var selectedUser = (from p in db.PHOTO_USER
                                        where p.USERNAME == username
                                        && p.PASSWORD == password
                                        select p).SingleOrDefault();

                    return selectedUser;
                }
            }
            catch (Exception)
            {
                throw new ModelErrorException();
            }
        }
    }
}
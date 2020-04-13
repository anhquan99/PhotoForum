using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Service.ModelService
{
    public class UserService : IService<FORUM_USER>
    {
        public bool create(FORUM_USER t)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    db.FORUM_USER.Add(t);
                    if (db.SaveChanges() == 0) return false;
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool deleteById(string username)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    var selectedUser = (from p in db.FORUM_USER
                                        where p.USERNAME == username
                                        select p).SingleOrDefault();
                    db.FORUM_USER.Remove(selectedUser);
                    if (db.SaveChanges() == 0) return false;
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<FORUM_USER> findAll()
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    return db.FORUM_USER.ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public FORUM_USER findById(string username)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    var selectedUser = (from p in db.FORUM_USER
                                        where p.USERNAME == username
                                        select p).SingleOrDefault();
                    return selectedUser;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool update(FORUM_USER t)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    var selectedUser = (from p in db.FORUM_USER
                                        where p.USERNAME == t.USERNAME
                                        select p).SingleOrDefault();
                    selectedUser.PASSWORD = t.PASSWORD;
                    selectedUser.EMAIL = t.EMAIL;
                    if (db.SaveChanges() == 0) return false;
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public FORUM_USER findByUsernameAndPassword(String username, String password)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    var selectedUser = (from p in db.FORUM_USER
                                        where p.USERNAME == username
                                        && p.PASSWORD == password
                                        select p).SingleOrDefault();

                    return selectedUser;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Service.ModelService
{
    public class LinkedUserService : IService<LINKED_USER>
    {
        public bool create(LINKED_USER t)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    db.LINKED_USER.Add(t);
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
                    var selectedUser = (from p in db.LINKED_USER
                                        where p.USERNAME == username
                                        select p).SingleOrDefault();
                    db.LINKED_USER.Remove(selectedUser);
                    if (db.SaveChanges() == 0) return false;
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<LINKED_USER> findAll()
        {
            throw new NotImplementedException();
        }

        public LINKED_USER findById(string username)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    return (from p in db.LINKED_USER
                            where p.USERNAME == username
                            select p).SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool update(LINKED_USER t)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    var selectedUser = (from p in db.LINKED_USER
                                        where p.USERNAME == t.USERNAME
                                        select p).SingleOrDefault();
                    selectedUser.LINKED_USERNAME = t.LINKED_USERNAME;
                    if (db.SaveChanges() == 0) return false;
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public LINKED_USER findByLinkedName(String name)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    var selectedUser = (from p in db.LINKED_USER
                                        where p.LINKED_USERNAME == name
                                        select p).SingleOrDefault();
                    return selectedUser;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
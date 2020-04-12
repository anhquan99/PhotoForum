using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Service.ModelService
{
    public class PostService : IService<POST>
    {
        public bool create(POST t)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    db.POSTs.Add(t);
                    if (db.SaveChanges() == 0) return false;
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool deleteById(string id)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    int postId = int.Parse(id);
                    var post = (from p in db.POSTs
                                where p.ID == postId
                                select p).SingleOrDefault();
                    db.POSTs.Remove(post);
                    if (db.SaveChanges() == 0) return false;
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool ApproveById(string id)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    int postId = int.Parse(id);
                    var post = (from p in db.POSTs
                                where p.ID == postId
                                select p).SingleOrDefault();
                    post.STATUS = "APPROVED";
                    if (db.SaveChanges() == 0) return false;
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<POST> findAll()
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    return (from p in db.POSTs
                            orderby p.ID descending
                            select p).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<POST> findPending()
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    return (from p in db.POSTs
                            where p.STATUS == "PENDING"
                            orderby p.ID descending
                            select p).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<POST> findApproved()
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    return (from p in db.POSTs
                            where p.STATUS == "APPROVED"
                            orderby p.ID descending
                            select p).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public POST findById(string id)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    int postId = int.Parse(id);
                    return (from p in db.POSTs
                            where p.ID == postId
                            select p).SingleOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool update(POST t)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    var post = (from p in db.POSTs
                                where p.ID == t.ID
                                select p).SingleOrDefault();
                    post.NAME = t.NAME;
                    post.CAPTION = t.CAPTION;
                    post.LINKED_LINK = t.LINKED_LINK;
                    if (db.SaveChanges() == 0) return false;
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<POST> findByUsername(String username)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    return (from p in db.POSTs
                            where p.USERNAME == username
                            orderby p.ID descending
                            select p).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
using PhotoForum.CustomException;
using PhotoForum.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoForum.Service.ModelService
{
    public class TagService : IService<TAG>
    {
        /// <summary>
        /// creat tag
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool create(TAG t)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    db.TAGs.Add(t);
                    if (db.SaveChanges() == 0) throw new ModelErrorException("ERROR: CREATING TAG AT TIME " + DateTime.Now.ToString() + " AT " + this.GetType().Name + "IN " + System.Reflection.MethodBase.GetCurrentMethod().ToString());
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// delete tag by tag name
        /// </summary>
        /// <param name="tagName">tag name</param>
        /// <returns></returns>
        public bool deleteById(string tagName)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    var selectedTag = (from p in db.TAGs
                                        where p.TAG_NAME == tagName
                                        select p).SingleOrDefault();

                    if (selectedTag != null)
                    {
                        db.TAGs.Remove(selectedTag);
                        if (db.SaveChanges() == 0) throw new ModelErrorException("ERROR: DELETING TAG AT TIME " + DateTime.Now.ToString() + " AT " + this.GetType().Name + "IN " + System.Reflection.MethodBase.GetCurrentMethod().ToString());
                    }
                    else throw new ModelErrorException("ERROR: TAG NOT FOUND");
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// get all tags
        /// </summary>
        /// <returns></returns>
        public List<TAG> findAll()
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    return (from p in db.TAGs select p).ToList();
                }
            }
            catch (Exception)
            {
                throw new ModelErrorException("ERROR: READING TAG AT TIME " + DateTime.Now.ToString() + " AT " + this.GetType().Name + "IN " + System.Reflection.MethodBase.GetCurrentMethod().ToString());
            }
        }
        /// <summary>
        /// find tag by tag name
        /// </summary>
        /// <param name="tagName">tag name</param>
        /// <returns></returns>
        public TAG findById(string tagName)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    var selectedTag = (from p in db.TAGs
                                        where p.TAG_NAME == tagName
                                        select p).SingleOrDefault();

                    return selectedTag;
                }
            }
            catch (Exception)
            {
                throw new ModelErrorException();
            }
        }
        /// <summary>
        /// can not update dual to field of the class
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool update(TAG t)
        {
            throw new NotImplementedException();
        }
    }
}
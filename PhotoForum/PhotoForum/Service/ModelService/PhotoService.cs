using PhotoForum.CustomException;
using PhotoForum.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoForum.Service.ModelService
{
    public class PhotoService : IService<IMG>
    {
        /// <summary>
        /// create img
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool create(IMG t)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    db.IMGs.Add(t);
                    if (db.SaveChanges() == 0) throw new Exception();
                    return true;
                }
            }
            catch (Exception)
            {
                throw new ModelErrorException("ERROR: CREATING IMG AT TIME " + DateTime.Now.ToString() + " AT " + this.GetType().Name + "IN " + System.Reflection.MethodBase.GetCurrentMethod().ToString());
            }
        }
        /// <summary>
        /// delete img by img id
        /// </summary>
        /// <param name="id">img id</param>
        /// <returns></returns>
        public bool deleteById(string id)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    int ID = int.Parse(id);
                    var selectedIMG = (from p in db.IMGs
                                        where p.IMG_ID == ID
                                        select p).SingleOrDefault();

                    if (selectedIMG != null)
                    {
                        db.IMGs.Remove(selectedIMG);
                        if (db.SaveChanges() == 0) throw new Exception();
                    }
                    else throw new ModelErrorException("ERROR: USER NOT FOUND");
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new ModelErrorException("ERROR: DELETING IMG AT TIME " + DateTime.Now.ToString() + " AT " + this.GetType().Name + "IN " + System.Reflection.MethodBase.GetCurrentMethod().ToString());
            }
        }
        /// <summary>
        /// get all img
        /// </summary>
        /// <returns></returns>
        public List<IMG> findAll()
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    return (from p in db.IMGs select p).ToList();
                }
            }
            catch (Exception)
            {
                throw new ModelErrorException("ERROR: READING IMG AT TIME " + DateTime.Now.ToString() + " AT " + this.GetType().Name + "IN " + System.Reflection.MethodBase.GetCurrentMethod().ToString());
            }
        }
        /// <summary>
        /// find by img id
        /// </summary>
        /// <param name="id">img id</param>
        /// <returns></returns>
        public IMG findById(string id)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    int ID = int.Parse(id);
                    var selectedIMG = (from p in db.IMGs
                                        where p.IMG_ID == ID
                                        select p).SingleOrDefault();

                    return selectedIMG;
                }
            }
            catch (Exception)
            {
                throw new ModelErrorException();
            }
        }
        /// <summary>
        /// update img
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool update(IMG t)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    var selectedIMG = (from p in db.IMGs
                                       where p.IMG_ID == t.IMG_ID
                                       select p).SingleOrDefault();

                    if (selectedIMG != null)
                    {
                        selectedIMG.IMG_NAME = t.IMG_NAME;
                        selectedIMG.STATUS = t.STATUS;
                        selectedIMG.UPLOAD_DATE = t.UPLOAD_DATE;
                        selectedIMG.TAGs = t.TAGs;
                        if (db.SaveChanges() == 0) throw new Exception();
                    }
                    else throw new ModelErrorException("ERROR: IMG NOT FOUND");
                    return true;
                }
            }
            catch (Exception)
            {
                throw new ModelErrorException("ERROR: DELETING IMG AT TIME " + DateTime.Now.ToString() + " AT " + this.GetType().Name + "IN " + System.Reflection.MethodBase.GetCurrentMethod().ToString());
            }
        }
        /// <summary>
        /// get the newest uploaded of the user 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int findNewestImgOfUser(String username)
        {
            try
            {
                using (PHOTO_FORUMEntities db = new PHOTO_FORUMEntities())
                {
                    int result = 0;
                    foreach (var i in db.SELECT_NEWEST_IMG(username))
                    {
                        result = i.IMG_ID;
                    }
                    if(result == 0)
                    {
                        throw new ModelErrorException("ERROR: USERNAME NOT FOUND");
                    }
                    return result;
                }
            }
            catch (Exception)
            {
                throw new ModelErrorException("ERROR: GETTING IMG AT TIME " + DateTime.Now.ToString() + " AT " + this.GetType().Name + "IN " + System.Reflection.MethodBase.GetCurrentMethod().ToString());
            }
        }

    }
}
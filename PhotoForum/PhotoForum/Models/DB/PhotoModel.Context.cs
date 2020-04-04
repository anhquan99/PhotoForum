﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhotoForum.Models.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PHOTO_FORUMEntities : DbContext
    {
        public PHOTO_FORUMEntities()
            : base("name=PHOTO_FORUMEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<IMG> IMGs { get; set; }
        public virtual DbSet<PHOTO_USER> PHOTO_USER { get; set; }
        public virtual DbSet<TAG> TAGs { get; set; }
    
        public virtual ObjectResult<FIND_IMG_WITH_TAG_Result> FIND_IMG_WITH_TAG(string tAG_NAME)
        {
            var tAG_NAMEParameter = tAG_NAME != null ?
                new ObjectParameter("TAG_NAME", tAG_NAME) :
                new ObjectParameter("TAG_NAME", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<FIND_IMG_WITH_TAG_Result>("FIND_IMG_WITH_TAG", tAG_NAMEParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> FIND_IMG_WITH_TAG_AND_USERNAME(string tAG_NAME, string uSERNAME)
        {
            var tAG_NAMEParameter = tAG_NAME != null ?
                new ObjectParameter("TAG_NAME", tAG_NAME) :
                new ObjectParameter("TAG_NAME", typeof(string));
    
            var uSERNAMEParameter = uSERNAME != null ?
                new ObjectParameter("USERNAME", uSERNAME) :
                new ObjectParameter("USERNAME", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("FIND_IMG_WITH_TAG_AND_USERNAME", tAG_NAMEParameter, uSERNAMEParameter);
        }
    
        public virtual ObjectResult<SELECT_NEWEST_IMG_Result> SELECT_NEWEST_IMG(string uSERNAME)
        {
            var uSERNAMEParameter = uSERNAME != null ?
                new ObjectParameter("USERNAME", uSERNAME) :
                new ObjectParameter("USERNAME", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SELECT_NEWEST_IMG_Result>("SELECT_NEWEST_IMG", uSERNAMEParameter);
        }
    }
}

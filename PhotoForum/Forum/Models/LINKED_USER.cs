//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Forum.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class LINKED_USER
    {
        public string USERNAME { get; set; }
        public string LINKED_USERNAME { get; set; }
    
        public virtual FORUM_USER FORUM_USER { get; set; }
    }
}

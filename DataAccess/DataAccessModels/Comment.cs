//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess.DataAccessModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public Comment()
        {
            this.CreateDate = DateTime.Now;
        }

        public int CommentId { get; set; }
        public string Comments { get; set; }
        public System.DateTime CreateDate { get; set; }
        public int EventId { get; set; }
    
        public virtual Event Event { get; set; }
    }
}

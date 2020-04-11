using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EventsMVCProject.Models
{
    public class EventsMVCProjectContext : DbContext
    {
        
    
        public EventsMVCProjectContext() : base("name=EventsMVCProjectContext")
        {
        }

        public System.Data.Entity.DbSet<EventsMVCProject.ViewModels.AccountViewModel> AccountViewModels { get; set; }

        public System.Data.Entity.DbSet<EventsMVCProject.ViewModels.EventTitleViewModel> EventTitleViewModels { get; set; }

        //public System.Data.Entity.DbSet<EventsMVCProject.Models.Account> Accounts { get; set; }
    }
}

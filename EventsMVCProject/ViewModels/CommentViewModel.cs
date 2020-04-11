using System;
using System.ComponentModel.DataAnnotations;

namespace EventsMVCProject.ViewModels
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }

        public string Comments { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreateDate { get; set; }

        public int EventId { get; set; }
    }
}
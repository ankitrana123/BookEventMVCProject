using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventsMVCProject.ViewModels
{
    public class EventViewModel
    {
        
        public int EventId { get; set; }

        public string Title { get; set; }

        public string StartTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EventDate { get; set; }

        [Display(Name ="Is Public ?")]
        public bool? TypeOfEvent { get; set; }

        public int? DurationInHours { get; set; }

        public string Description { get; set; }

        public string OtherDetails { get; set; }

        public string InviteByEmail { get; set; }

        public IEnumerable<CommentViewModel> commentViewModels { get; set; }
    }
}
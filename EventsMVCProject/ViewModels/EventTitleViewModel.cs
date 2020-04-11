using System;
using System.ComponentModel.DataAnnotations;

namespace EventsMVCProject.ViewModels
{
    public class EventTitleViewModel
    {
        public int Id { get; set; }
        
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

    }
}
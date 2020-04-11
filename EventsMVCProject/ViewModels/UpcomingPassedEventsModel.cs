using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventsMVCProject.ViewModels
{
    public class UpcomingPassedEventsModel
    {
        public IEnumerable<EventTitleViewModel> PassedEvents { get; set; }

        public IEnumerable<EventTitleViewModel> FutureEvents { get; set; }

    }
}
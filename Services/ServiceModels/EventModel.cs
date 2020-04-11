using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceModels
{
    public class EventModel
    {
        public int EventId { get; set; }

        public string Title { get; set; }

        public DateTime EventDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public string StartTime { get; set; }

        public bool? TypeOfEvent { get; set; }

        public int? DurationInHours { get; set; }

        public string Description { get; set; }

        public string OtherDetails { get; set; }

        public string InviteByEmail { get; set; }

        public IEnumerable<CommentModel> Comments { get; set; }


    }
}

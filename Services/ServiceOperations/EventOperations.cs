using DataAccess.DataAccessModels;
using DataAccess.DataAccessServices;
using Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServiceOperations
{
    public class EventOperations
    {
        public List<EventModel> getAllPublicEvents()
        {
            EventDataAccess eventDataAcess = new EventDataAccess();
            var allPublicEventsList = eventDataAcess.getAllPublicEvents().Select(eventDetails => new EventModel()
            {
                EventId = eventDetails.EventId,

                Title = eventDetails.Title,

                EventDate = eventDetails.EventDate,



            }).ToList();
            return allPublicEventsList;
        }


        public int createEvent(EventModel bookEvent, string Username)
        {
            Event eventEntity = new Event()
            {
                Title = bookEvent.Title,

                StartTime = bookEvent.StartTime,

                TypeOfEvent = (bool)bookEvent.TypeOfEvent,

                EventDate = bookEvent.EventDate,


                DurationInHours = bookEvent.DurationInHours,

                Description = bookEvent.Description,

                OtherDetails = bookEvent.OtherDetails,

                InviteByEmail = bookEvent.InviteByEmail,

            };
            EventDataAccess eventDataAcess = new EventDataAccess();
            int newEvent = eventDataAcess.createEvent(eventEntity, Username);
            return newEvent;

        }

        public string[] getRolesOfUser(string username)
        {
            EventDataAccess eventDataAccess = new EventDataAccess();
            return eventDataAccess.getRolesFromTable(username);
        }

        public void editEvent(EventModel eventModel)
        {
            Event eventEntity = new Event()
            {
                EventId = eventModel.EventId,

                Title = eventModel.Title,

                StartTime = eventModel.StartTime,

                TypeOfEvent = (bool)eventModel.TypeOfEvent,

                EventDate = eventModel.EventDate,

                DurationInHours = eventModel.DurationInHours,

                Description = eventModel.Description,

                OtherDetails = eventModel.OtherDetails,

                InviteByEmail = eventModel.InviteByEmail,
            };
            EventDataAccess eventDataAcess = new EventDataAccess();
            eventDataAcess.editEvent(eventEntity);
        }

        public EventModel getDetailsOfEvent(int eventid)
        {
            EventDataAccess eventDataAcess = new EventDataAccess();
            var eventDetails = eventDataAcess.getDetailsOfEvent(eventid);
            EventModel eventModel = new EventModel()
            {
                Title = eventDetails.Title,

                StartTime = eventDetails.StartTime,

                TypeOfEvent = eventDetails.TypeOfEvent,

                EventDate = eventDetails.EventDate,

                DurationInHours = eventDetails.DurationInHours,

                Description = eventDetails.Description,

                OtherDetails = eventDetails.OtherDetails,

                InviteByEmail = eventDetails.InviteByEmail,

                Comments = eventDetails.Comments.Select(x => new CommentModel()

                {

                    CreateDate = x.CreateDate,

                    Comments = x.Comments,

                }),


            };
            return eventModel;
        }

        public List<EventModel> getAllEvents()
        {
            EventDataAccess eventDataAcess = new EventDataAccess();
            var allEventsList = eventDataAcess.getAllEvents().Select(eventDetails => new EventModel()
            {
                EventId = eventDetails.EventId,

                Title = eventDetails.Title,

                EventDate = eventDetails.EventDate,




            }).ToList();
            return allEventsList;
        }

        public List<EventModel> myEvents(string username)
        {
            EventDataAccess eventDataAcess = new EventDataAccess();
            var myEventsList = eventDataAcess.myEvents(username).Select(eventDetails => new EventModel()
            {
                EventId = eventDetails.EventId,

                Title = eventDetails.Title,

                EventDate = eventDetails.EventDate


            }).ToList();
            return myEventsList;

        }

        public List<EventModel> eventsInvitedTo(string username)
        {
            EventDataAccess eventDataAcess = new EventDataAccess();
            var myEventsList = eventDataAcess.myEvents(username).Select(eventDetails => new EventModel()
            {
                EventId = eventDetails.EventId,

                Title = eventDetails.Title,

                EventDate = eventDetails.EventDate


            }).ToList();
            return myEventsList;

        }

        public void addComment(CommentModel commentModel)
        {
            EventDataAccess eventDataAccess = new EventDataAccess();
            Comment comment = new Comment()
            {
                Comments = commentModel.Comments,
                EventId = commentModel.EventId
            };
            eventDataAccess.addComment(comment);
        }


    }
}

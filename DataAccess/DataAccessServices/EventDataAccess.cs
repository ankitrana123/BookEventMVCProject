using DataAccess.DataAccessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccessServices
{
    public class EventDataAccess
    {
        public List<Event> getAllPublicEvents()
        {
            using (var context = new EventsDBEntities())
            {
                var requiredEvents = context.Events.OrderBy(allEvents => allEvents.EventDate)
                                       .Where(allEvents => allEvents.TypeOfEvent == true)
                                       .ToList();
                return requiredEvents;
            }
        }

        public int createEvent(Event bookEvent, string username)
        {
            using (var context = new EventsDBEntities())
            {
                bookEvent.UserId = getUserId(username);
                context.Events.Add(bookEvent);
                context.SaveChanges();
                return bookEvent.EventId;
            };
        }

        public void editEvent(Event eventEntity)
        {
            using (var context = new EventsDBEntities())
            {

                var requiredEvent = context.Events.Where(events => events.EventId == eventEntity.EventId).FirstOrDefault();
                requiredEvent.Title = eventEntity.Title;
                requiredEvent.StartTime = eventEntity.StartTime;
                requiredEvent.InviteByEmail = eventEntity.InviteByEmail;
                requiredEvent.OtherDetails = eventEntity.InviteByEmail;
                requiredEvent.TypeOfEvent = eventEntity.TypeOfEvent;
                requiredEvent.Description = eventEntity.Description;
                requiredEvent.EventDate = eventEntity.EventDate;
                requiredEvent.ModifyDate = DateTime.Now;
                context.SaveChanges();

            }
        }

        public Event getDetailsOfEvent(int eventid)
        {
            using (var context = new EventsDBEntities())
            {
                var comments = context.Comments.Where(comment => comment.EventId == eventid)
                                .OrderBy(comment => comment.CreateDate)
                                .ToList();

                var requiredEvent = context.Events.Where(aEvent => aEvent.EventId == eventid).FirstOrDefault();

                return requiredEvent;
            };

        }

        public string[] getRolesFromTable(string emailId)
        {
            using (var context = new EventsDBEntities())
            {
                var userRoles = (from user in context.Users
                                 join roleMapping in context.UserRolesMappings
                                 on user.UserId equals roleMapping.UserId
                                 join role in context.RoleMasters
                                 on roleMapping.RoleId equals role.RoleId
                                 where user.EmailId == emailId
                                 select role.RoleName).ToArray();



                return userRoles;
            }
        }

        public List<Event> getAllEvents()
        {
            using (var context = new EventsDBEntities())
            {
                return context.Events.ToList();

            }
        }


        public List<Event> myEvents(string username)
        {

            using (var context = new EventsDBEntities())
            {
                int id = getUserId(username);
                return context.Events.Where(allEvents => allEvents.UserId == id).ToList();
            }

        }

        public int getUserId(string username)
        {
            using (var context = new EventsDBEntities())
            {
                int result = (from user in context.Users
                              where user.EmailId == username
                              select user.UserId).FirstOrDefault();
                return result;

            }
        }

        public void addComment(Comment comment)
        {
            using (var context = new EventsDBEntities())
            {
                context.Comments.Add(comment);
                context.SaveChanges();
            }
        }


    }
}

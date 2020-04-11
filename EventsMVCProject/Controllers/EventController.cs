using EventsMVCProject.ViewModels;
using Services.ServiceModels;
using Services.ServiceOperations;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EventsMVCProject.Controllers
{
    public class EventController : Controller
    {
        //Create Method to Create a new event only User and Admin can create an event
        [Authorize(Roles = "User,Admin")]
        public ActionResult Create()
        {
            return View();
        }


        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        public ActionResult Create(EventViewModel eventViewModel)
        {
            EventModel eventModel = new EventModel()
            {
                Title = eventViewModel.Title,

                StartTime = eventViewModel.StartTime,

                TypeOfEvent = eventViewModel.TypeOfEvent,

                EventDate = eventViewModel.EventDate,

                DurationInHours = eventViewModel.DurationInHours,

                Description = eventViewModel.Description,

                OtherDetails = eventViewModel.OtherDetails,

                InviteByEmail = eventViewModel.InviteByEmail,


            };
            EventOperations eventOperation = new EventOperations();
            int eventId = eventOperation.createEvent(eventModel, User.Identity.Name);

            return RedirectToAction("Index", "Home");
        }

        //Returns all Public Events
        public ActionResult getAllPublicEvents()
        {
            EventOperations eventOperation = new EventOperations();
            var allPublicEventsList = eventOperation.getAllPublicEvents().Select(eventDetails => new EventTitleViewModel()
            {
                Id = eventDetails.EventId,

                Title = eventDetails.Title,

                Date = eventDetails.EventDate,

            }).ToList();
            var passedEvents = allPublicEventsList.Where(e => e.Date < DateTime.Now);

            var allupcomingEvents = allPublicEventsList.Where(e => e.Date >= DateTime.Now);


            return View(new UpcomingPassedEventsModel()
            {
                PassedEvents = passedEvents,
                FutureEvents = allupcomingEvents
            }
            );
        }

        //Returns the Events Created by a Particular User
        [Authorize(Roles = "User,Admin")]
        public ActionResult MyEvents()
        {
            var currentUser = User.Identity.Name;
            EventTitleViewModel eventTitle = new EventTitleViewModel();
            EventOperations eventOperation = new EventOperations();
            var result = eventOperation.myEvents(currentUser).Select(eventDetails => new EventTitleViewModel()
            {
                Id = eventDetails.EventId,

                Title = eventDetails.Title,

                Date = eventDetails.EventDate,

            }).ToList();
            var passedEvents = result.Where(e => e.Date < DateTime.Now);

            var allupcomingEvents = result.Where(e => e.Date >= DateTime.Now);


            return View("MyEvents", new UpcomingPassedEventsModel()
            {
                PassedEvents = passedEvents,
                FutureEvents = allupcomingEvents
            }
            );
        }

        //Returns all the events for which the user was Invited to
        [Authorize(Roles = "User,Admin")]
        public ActionResult EventInvitedTo()
        {
            EventOperations eventOperation = new EventOperations();
            var result = eventOperation.eventsInvitedTo(User.Identity.Name).Select(events => new EventTitleViewModel()
            {
                Id = events.EventId,

                Title = events.Title,

                Date = events.EventDate,
            }).ToList();
            var passedEvents = result.Where(e => e.Date < DateTime.Now);

            var allupcomingEvents = result.Where(e => e.Date >= DateTime.Now);


            return View("EventInvitedTo", new UpcomingPassedEventsModel()
            {
                PassedEvents = passedEvents,
                FutureEvents = allupcomingEvents
            });

        }
        [Authorize(Roles = "Admin")]

        //Returns the the Created Events
        public ActionResult getAllEvents()
        {
            EventOperations eventOperation = new EventOperations();
            var result = eventOperation.getAllEvents().Select(events => new EventTitleViewModel()
            {
                Id = events.EventId,

                Title = events.Title,

                Date = events.EventDate,
            }).ToList();
            var passedEvents = result.Where(e => e.Date < DateTime.Now);

            var allupcomingEvents = result.Where(e => e.Date >= DateTime.Now);


            return View("getAllEvents", new UpcomingPassedEventsModel()
            {
                PassedEvents = passedEvents,
                FutureEvents = allupcomingEvents
            });
        }

        //Edit event details using the id of event
        public ActionResult editEvent(int id)
        {
            EventOperations eventOperation = new EventOperations();
            var result = eventOperation.getDetailsOfEvent(id);
            EventViewModel eventViewModel = new EventViewModel()
            {
                EventId = result.EventId,

                Title = result.Title,

                StartTime = result.StartTime,

                TypeOfEvent = result.TypeOfEvent,

                DurationInHours = result.DurationInHours,

                Description = result.Description,

                OtherDetails = result.OtherDetails,

                InviteByEmail = result.InviteByEmail,

                commentViewModels = result.Comments.Select(x => new CommentViewModel()
                {
                    CreateDate = x.CreateDate,
                    Comments = x.Comments
                })


            };

            return View(eventViewModel);
        }

        //post method to edit the event
        [HttpPost]
        [ActionName("editEvent")]
        public ActionResult editEventPost(EventViewModel eventViewModel)
        {
            EventModel eventModel = new EventModel()
            {
                EventId = eventViewModel.EventId,

                Title = eventViewModel.Title,

                StartTime = eventViewModel.StartTime,

                TypeOfEvent = eventViewModel.TypeOfEvent,

                DurationInHours = eventViewModel.DurationInHours,

                Description = eventViewModel.Description,

                OtherDetails = eventViewModel.OtherDetails,

                InviteByEmail = eventViewModel.InviteByEmail,


            };
            EventOperations eventOperation = new EventOperations();
            eventOperation.editEvent(eventModel);
            return RedirectToAction("MyEvents", "Event");

        }

        //gets the details of an event using its id
        public ActionResult getDetailsofEvent(int id)
        {
            EventOperations eventOperation = new EventOperations();

            var requiredEvent = eventOperation.getDetailsOfEvent(id);
            EventViewModel eventView = new EventViewModel()
            {
                Title = requiredEvent.Title,

                StartTime = requiredEvent.StartTime,

                TypeOfEvent = requiredEvent.TypeOfEvent,

                EventDate = requiredEvent.EventDate,

                DurationInHours = requiredEvent.DurationInHours,

                Description = requiredEvent.Description,

                OtherDetails = requiredEvent.OtherDetails,

                InviteByEmail = requiredEvent.InviteByEmail,

                commentViewModels = requiredEvent.Comments.Select(x => new CommentViewModel()

                {

                    CreateDate = x.CreateDate,

                    Comments = x.Comments,

                }),

            };

            return View(eventView);
        }

        [HttpPost]
        [Authorize(Roles = "User , Admin")]
        public ActionResult getDetailsofEvent(CommentViewModel commentViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            EventOperations eventOperation = new EventOperations();
            CommentModel commentModel = new CommentModel()
            {
                Comments = commentViewModel.Comments,
                EventId = commentViewModel.EventId
            };
            eventOperation.addComment(commentModel);
            return RedirectToAction("MyEvents", "Event");
        }
    }
}
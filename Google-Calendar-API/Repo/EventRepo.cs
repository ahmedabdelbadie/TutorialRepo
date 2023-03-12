using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google_Calendar_API.Auth;
using Google_Calendar_API.Models;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Google_Calendar_API.Repo
{
    public class EventRepo : IEventRepo
    {
        private CalendarService _calendarService;
        private const string primarycalenderID = "primary";
        public string calenderID;
        private string _calenderID 
        {
            set
            {
                calenderID = value;
            }
            get
            {
                return calenderID ?? primarycalenderID;
            }
        }
        public EventRepo(CalendarService calendarService)
        {
            _calendarService = calendarService;

        }

        public void DeleteEvent(string eventid)
        {
            try
            {
                _calendarService.Events.Delete(_calenderID, eventid).Execute();


            } catch (Exception ex)
            {

            }

        }
        public void setCalenderID(string calender)
        {
            _calenderID = calender;

        }

        public IEnumerable<EventDTO> GetAll()
        {
            // List events.
            EventsResource.ListRequest listRequest = _calendarService.Events.List(_calenderID);
            listRequest.TimeMin = DateTime.Now;
            listRequest.ShowDeleted = false;
            listRequest.SingleEvents = true;
            listRequest.MaxResults = 10;
            listRequest.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;
            Events events = listRequest.Execute();

            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (Event eventItem in events.Items)
                {
                    yield return new EventDTO() { 
                        Id = eventItem.Id,
                        Title = eventItem.Summary,
                        Description = eventItem.Description,   
                        start = eventItem.Start.DateTime.Value,
                        end = eventItem.End.DateTime.Value,
                    };
                   
                }
            }
            yield return null;
        }


        public void PostEvent(EventDTO eventDTO)
        {
            Event postEvent = new Event()
            {
                Id = "eventid" + Guid.NewGuid().ToString("N"),
                Summary = eventDTO.Title,
                Location = "None Location",
                Description = eventDTO.Description,
                Start = new EventDateTime()
                {
                    DateTime = eventDTO.start,
                    
                },
                End = new EventDateTime()
                {
                    DateTime = eventDTO.end,
                   
                },
              
            };
            var InsertRequest = _calendarService.Events.Insert(postEvent, _calenderID);
            try
            {
                InsertRequest.Execute();
            }
            catch (Exception)
            {
                try
                {
                    _calendarService.Events.Update(postEvent, _calenderID, postEvent.Id).Execute();
                    Console.WriteLine("Insert/Update new Event ");
                    Console.Read();

                }
                catch (Exception)
                {
                    Console.WriteLine("can't Insert/Update new Event ");

                }
            }

        }

        public IList<string> GetCalenderList()
        {
            List<string> _calendarList = new List<string>();
            try
            {
                var CalendarList = _calendarService.CalendarList.List().Execute().Items;

                foreach (var item in CalendarList)
                {
                    _calendarList.Add(item.Id);
                }
                return _calendarList;

            }
            catch (Exception ex)
            {
                return _calendarList;
            }

        }

        public EventDTO GetById(string eventID)
        {
            Event getEvent = _calendarService.Events.Get(_calenderID, eventID).Execute();
            return new EventDTO()
            {
                Title = getEvent.Summary,
                Description = getEvent.Description,
                start = getEvent.Start.DateTime.Value,
                end = getEvent.End.DateTime.Value,
            };
        }
    }
}

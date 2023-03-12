using System.IO;
using System.Threading;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Web;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Globalization;
using Google_Calendar_API.Auth;
using Google_Calendar_API.Repo;
using Google_Calendar_API.Helper;
using static System.Net.Mime.MediaTypeNames;
using Google_Calendar_API.Models;
using Google_Calendar_API.Service;
using Google_Calendar_API.Exceptions;
using System.Net;
using System.Net.Mail;

namespace Google_Calendar_API
{
    /// <summary>
    /// This example uses the discovery API to list all APIs in the discovery repository.
    /// https://developers.google.com/discovery/v1/using.
    /// <summary>
    class Program
    {
        private static EventRepo _eventRepo;
        static async Task Main(string[] args)
        {

            char ch;
            string? eventID;
            EventDTO? eventDTO;
            IEnumerable<EventDTO>? eventDTOs;
            while (true)
            {
                Messages.getMessages(_eventRepo != null ? true : false);
               
                Console.WriteLine("Enter your Chioce");
                ch = Convert.ToChar(Console.ReadLine());
                switch (Char.ToUpper(ch))
                {
                     
                    case 'Y':
                        IGoogleAuth googleAuth = Singleton.GetInstance();
                        _eventRepo = new EventRepo(googleAuth.CalendarService);
                        break;
                    case 'A':
                        try
                        {
                            if (_eventRepo == null) throw new UNAuthorize("User not Autherize Please retry Autherization");
                            var calenderList = _eventRepo.GetCalenderList();
                            var calenderID = Messages.getSelectedCalenderList(calenderList);
                            if (calenderID != null)
                            {
                                _eventRepo.setCalenderID(calenderID);
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                       
                        break;
                    case 'B':
                        try
                        {
                            if (_eventRepo == null) throw new UNAuthorize("User not Autherize Please retry Autherization");
                            eventDTOs = _eventRepo.GetAll();
                            foreach (var eventitem in eventDTOs)
                            {
                                Messages.DisplayEvent(eventitem);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                        break;
                    case 'C':
                        try
                        {
                            if (_eventRepo == null) throw new UNAuthorize("User not Autherize Please retry Autherization");
                            eventDTO = Messages.getPreparedEventDTO(); //Messages.getEventDTO();//Messages.getPreparedEventDTO();
                            _eventRepo.PostEvent(eventDTO);
                            Console.WriteLine($"Event Title is created '{eventDTO.Title}'");
                            Console.WriteLine($"Do you need to send notification Email");

                            ch = Convert.ToChar(Console.ReadLine());
                            if(ch == 'y')
                            {
                                string mail = null;
                                if (!IsValid(_eventRepo.calenderID)) mail = Convert.ToString(Console.ReadLine());
                                else mail = _eventRepo.calenderID;
                                new EmailService().SendEmail(mail, eventDTO);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                        break;
                    case 'D':
                        try
                        {
                            if (_eventRepo == null) throw new UNAuthorize("User not Autherize Please retry Autherization");
                            eventDTOs = _eventRepo.GetAll();
                            eventID = Messages.getSelectedEventId(eventDTOs.ToList());
                            _eventRepo.DeleteEvent(eventID);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                        break;
                    case 'G':
                        try
                        {
                            if (_eventRepo == null) throw new UNAuthorize("User not Autherize Please retry Autherization");
                            eventDTOs = _eventRepo.GetAll();
                            eventID = Messages.getSelectedEventId(eventDTOs.ToList<EventDTO>());
                            var eventDto = _eventRepo.GetById(eventID);
                            Messages.DisplayEvent(eventDto);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            break;
                        }
                        break;
                    case 'E':
                        Environment.Exit(0);
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }
            }
            static bool IsValid(string email)
            {
                var valid = true;

                try
                {
                    var emailAddress = new MailAddress(email);
                }
                catch
                {
                    valid = false;
                }

                return valid;
            }

            /*
            var googlAuth = new GoogleAuthentication();
            var calenderService = googlAuth.AuthenticateApp();

            var request = calenderService.Events.List(GoogleAuthentication._calenderID);

            var response = await request.ExecuteAsync();

            foreach(var item in response.Items)
            {
                Console.WriteLine($"Holiday {item.Summary} start date {item.Start.Date} end {item.End.da}");
            }

            
            var CalendarList = googlAuth.CalendarService.CalendarList.List().Execute().Items;
            foreach (var item in CalendarList)
            {
                Console.WriteLine(item.Id);
            }
            // Define parameters of request.
            EventsResource.ListRequest listRequest = googlAuth.CalendarService.Events.List("eng.ahmed9466@gmail.com");
            listRequest.TimeMin = DateTime.Now;
            listRequest.ShowDeleted = false;
            listRequest.SingleEvents = true;
            listRequest.MaxResults = 10;
            listRequest.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            // List events.
            Events events = listRequest.Execute();
            
            Console.WriteLine("Upcoming events:");
            if (events.Items != null && events.Items.Count > 0)
            {
                foreach (var eventItem in events.Items)
                {
                    string when = eventItem.Start.DateTime.ToString();
                    if (String.IsNullOrEmpty(when))
                    {
                        when = eventItem.Start.Date;
                    }
                    Console.WriteLine("{0} ({1})", eventItem.Summary, when);
                }
            }
            else
            {
                Console.WriteLine("No upcoming events found.");
            }
            Console.WriteLine("click for more .. ");
            //Console.ReadLine();

            var myevent = DB.Find(x => x.Id == "eventid" + 1);

            var InsertRequest = googlAuth.CalendarService.Events.Insert(myevent, "eng.ahmed9466@gmail.com");

            try
            {
                InsertRequest.Execute();
            }
            catch (Exception)
            {
                try
                {
                    googlAuth.CalendarService.Events.Update(myevent, "eng.ahmed9466@gmail.com", myevent.Id).Execute();
                    Console.WriteLine("Insert/Update new Event ");
                    Console.Read();

                }
                catch (Exception)
                {
                    Console.WriteLine("can't Insert/Update new Event ");

                }
            }*/

        }
        /*
        static List<Event> DB =
             new List<Event>() {
                new Event(){
                    Id = "eventid" + 1,
                    Summary = "Google I/O 2015",
                    Location = "800 Howard St., San Francisco, CA 94103",
                    Description = "A chance to hear more about Google's developer products.",
                    Start = new EventDateTime()
                    {
                        DateTime = new DateTime(2023, 03, 13, 15, 30, 0),
                        TimeZone = "America/Los_Angeles",
                    },
                    End = new EventDateTime()
                    {
                        DateTime = new DateTime(2023, 03, 14, 15, 30, 0),
                        TimeZone = "America/Los_Angeles",
                    },
                     Recurrence = new List<string> { "RRULE:FREQ=DAILY;COUNT=2" },
                    Attendees = new List<EventAttendee>
                    {
                        new EventAttendee() { Email = "lpage@example.com"},
                        new EventAttendee() { Email = "sbrin@example.com"}
                    }
                }
             };
        */



    }
}
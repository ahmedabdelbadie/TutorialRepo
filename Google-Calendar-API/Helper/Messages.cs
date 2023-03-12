using Google.Apis.Calendar.v3.Data;
using Google_Calendar_API.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_Calendar_API.Helper
{
    public static class Messages
    {
        public static void getMessages(bool auth = false)
        {
            if (!auth)
            {
                Console.WriteLine("you have to authorize to procced");
                Console.WriteLine("Authorize App --> Enter Y");
            }
            else
            {
                Console.WriteLine("Choices:");
                Console.WriteLine("[A] List Calender List");
                Console.WriteLine("[B] List All Upcoming Events");
                Console.WriteLine("[C] Create New Event");
                Console.WriteLine("[D] Delete Event By ID");
                Console.WriteLine("[G] Get Event By ID");
                Console.WriteLine("[E] Close App");
                Console.WriteLine("[*] Exit App");

            }


        }
        public static void DisplayEvent(EventDTO eventDto)
        {
            if(eventDto != null)
            {
                Console.WriteLine($"\n-------- Event -----------");
                Console.WriteLine($"Event Title '{eventDto.Title}'");
                Console.WriteLine($"Event Descrition '{eventDto.Description}'");
                Console.WriteLine($"start Event date {eventDto.start} End {eventDto.end}");
                Console.WriteLine($"-------- END Event -----------\n");

            }
        }
        public static string getSelectedEventId(IList<EventDTO> events)
        {
            int ch;
            do
            {
                Console.WriteLine("Please Select the Event by id");
                for (int i = 0; i < events.Count; i++)
                {
                    if (events[i] != null)
                    {
                        Console.WriteLine($"{i} - Event Title {events[i].Title}");

                    }
                }

                Console.WriteLine("Enter your Chioce");
                ch = Convert.ToInt16(Console.ReadLine());
            } while (ch > events.Count && ch < 0);

            return events[ch].Id;

        }
        public static string getSelectedCalenderList(IList<string> calenderList)
        {
            int index;
            do
            {
                Console.WriteLine("Please Select the Event by id");
                for (int i = 0; i < calenderList.Count; i++)
                {
                    Console.WriteLine($"{i} - Calender Name {calenderList[i]}");
                }

                Console.WriteLine("Enter your Chioce");
                index = Convert.ToInt16(Console.ReadLine());
            } while (index < calenderList.Count && index > 0);

            return calenderList[index];

        }
        public static EventDTO getEventDTO()
        {
            
            string d;
            EventDTO eventDTO = new EventDTO();

            Console.WriteLine("Please Enter the Event Data");

            do
            {
                Console.WriteLine("Please Enter the Event Title");
                d = Convert.ToString(Console.ReadLine());

            } while (string.IsNullOrEmpty(d));
            eventDTO.Title = d;


            do
            {
                Console.WriteLine("Please Enter the Event Descrition");
                d = Convert.ToString(Console.ReadLine());
            } while (string.IsNullOrEmpty(d));

            eventDTO.Description = d;

            DateTime dt;
            do
            {
                Console.WriteLine("Please Enter the Event start date in format yyyy-dd-MM hh:mm tt");
                d = Convert.ToString(Console.ReadLine());
            } while (!DateTime.TryParseExact(d,
                       "yyyy-dd-MM hh:mm tt",
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out dt));

            eventDTO.start = dt;

            do
            {
                Console.WriteLine("Please Enter the Event End date in format yyyy-dd-MM hh:mm tt");
                d = Convert.ToString(Console.ReadLine());
            } while (!DateTime.TryParseExact(d,
                      "yyyy-dd-MM hh:mm tt",
                      CultureInfo.InvariantCulture,
                      DateTimeStyles.None,
                      out dt));
            eventDTO.end = dt;
            return eventDTO;
        }
        public static EventDTO getPreparedEventDTO()
        {
            return new EventDTO()
            {
                Title = "TT",
                Description ="Desc",
                start =  new DateTime(2023, 03, 14, 15, 30, 0),
                end =  new DateTime(2023, 03, 14, 15, 30, 0),
            };
            
        }
    }
}

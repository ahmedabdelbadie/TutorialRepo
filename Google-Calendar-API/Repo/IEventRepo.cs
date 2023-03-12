using Google_Calendar_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_Calendar_API.Repo
{
    public interface IEventRepo
    {
        IEnumerable<EventDTO> GetAll();
        EventDTO GetById(string eventID);
        void PostEvent(EventDTO eventDTO);
        void DeleteEvent(string eventid);
        IList<string> GetCalenderList();
 
    }
}

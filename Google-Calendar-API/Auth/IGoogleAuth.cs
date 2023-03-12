using Google.Apis.Calendar.v3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_Calendar_API.Auth
{
    public interface IGoogleAuth
    {
        CalendarService CalendarService { set; get; }
    }
}

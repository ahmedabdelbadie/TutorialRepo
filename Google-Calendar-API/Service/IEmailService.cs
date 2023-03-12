using Google_Calendar_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_Calendar_API.Service
{
    public interface IEmailService
    {
        void SendEmail(string mail, EventDTO eventDTO);
    }
}

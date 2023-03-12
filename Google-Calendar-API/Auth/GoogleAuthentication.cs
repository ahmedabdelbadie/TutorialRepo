using System.IO;
using System.Threading;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Web;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Google_Calendar_API.Auth
{
    public class GoogleAuthentication : IGoogleAuth
    {
        private CalendarService _calendarService;
        public CalendarService CalendarService
        {
            set
            {
                _calendarService = value;
            }
            get
            {
                return _calendarService;
            }
        }
        public static string _calenderID = "en.eg#holiday@group.v.calendar.google.com";
        public const string _APIKEY = "AIzaSyBtaV0opsRNv8JWei5grEUf5NwIsGTrBFc";
        public GoogleAuthentication()
        {
            _calendarService = AuthenticateApp();
        }
        public CalendarService AuthenticateApp()
        {

            try
            {

                // Create Calendar API service.    
                var service = new CalendarService(new BaseClientService.Initializer()
                {
                    ApiKey = _APIKEY,
                    ApplicationName = "CalenderKey",
                });
                return service;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}

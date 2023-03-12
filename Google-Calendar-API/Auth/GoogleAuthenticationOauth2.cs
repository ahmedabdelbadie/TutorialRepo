using System.IO;
using System.Threading;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Web;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.Util;
using Google.Apis.Gmail.v1;
using Google_Calendar_API.Exceptions;

namespace Google_Calendar_API.Auth
{
    public class GoogleAuthenticationOauth2 : IGoogleAuth
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
        public const string _clientID = "1025118665607-jmcthl16tglp88a3694bm1b4lh4nqvjk.apps.googleusercontent.com";
        public const string _clientsecret = "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";

        public GoogleAuthenticationOauth2()
        {
            CalendarService = AuthenticateApp();
        }
        private CalendarService AuthenticateApp()
        {


            try
            {
                string[] _scopes = { "https://www.googleapis.com/auth/calendar"
                        , "https://www.googleapis.com/auth/calendar.events"
                        , "https://www.googleapis.com/auth/calendar.events.readonly"
                        , "https://www.googleapis.com/auth/calendar.readonly"
                        , "https://www.googleapis.com/auth/calendar.settings.readonly"
                        , "https://www.googleapis.com/auth/gmail.readonly"
                };
                var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets
                    {
                        ClientId = _clientID,
                        ClientSecret = _clientsecret
                    }, _scopes, "user", CancellationToken.None).Result;
                if (credential == null) throw new UNAuthorize("User not Autherize Please retry Autherization");
                if (credential.Token.IsExpired(SystemClock.Default))
                    credential.RefreshTokenAsync(CancellationToken.None).Wait();
                var service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential
                });
               
                return service;
            }
            catch (Exception ex)
            {
                throw;
            }
            return null;
        }
    }
}

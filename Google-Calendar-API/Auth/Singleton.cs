using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_Calendar_API.Auth
{
    public sealed class Singleton
    {

        private Singleton() { }

       
        private static IGoogleAuth _instance;


        public static IGoogleAuth GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GoogleAuthenticationOauth2();
            }
            return _instance;
        }
    }
}

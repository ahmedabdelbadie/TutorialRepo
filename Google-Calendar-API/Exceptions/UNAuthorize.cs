using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_Calendar_API.Exceptions
{
    public class UNAuthorize : Exception
    {
        public UNAuthorize()
        {

        }
        public UNAuthorize(string name)
       : base($"Unauthorize User: {name}")
        {

        }
    }
}

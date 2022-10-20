using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Empty1Tutorial
{
    public class Variable
    {
        private IConfiguration _config;
        public Variable(IConfiguration configuration)
        {
            _config = configuration;
        }
        public  string getKey() {
            return _config["key"];

        }
    }
}

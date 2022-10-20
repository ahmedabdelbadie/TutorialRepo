using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace WebAppTutorial.Validation
{
    public class CustomEmailDomainValidation :  ValidationAttribute
    {
        private readonly string allowDomain;

        public CustomEmailDomainValidation(string allowDomain)
        {
            this.allowDomain = allowDomain;
        }
        public override bool IsValid(object? value)
        {
            string[] strings = value.ToString().Split("@");

            return strings[1].ToUpper() == allowDomain.ToUpper();
        }
    }
}

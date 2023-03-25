using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForTest.Models
{
    public class Patient
    {
        public Patient()
        {

        }
        public Patient(int age, string firstName, string lastName)
        {
            Age = age;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public int Age { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public override string ToString()
        {
            return $"patient name {firstName} {lastName} age {Age}";
        }

    }
}

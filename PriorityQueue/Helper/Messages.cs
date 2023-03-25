
using JustForTest.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_Calendar_API.Helper
{
    public static class Messages
    {
        public static void DS_Priority()
        {
            Console.WriteLine("Choices:");
            Console.WriteLine("[A] Circular Array Queue");
            Console.WriteLine("[B] Linked List Priority Queue");
            Console.WriteLine("[E] Close App");
            Console.WriteLine("[*] Exit App");

        }
        public static void getMessages()
        {
            Console.WriteLine("Choices:");
            Console.WriteLine("[A] Enqueue");
            Console.WriteLine("[B] Dequeue");
            Console.WriteLine("[C] Display");
            Console.WriteLine("[D] Delete");
            Console.WriteLine("[E] Close App");
            Console.WriteLine("[*] Exit App");

        }
        public static (Patient,int) getPatientDTO()
        {

            string d;
            

            Console.WriteLine("Please Enter the Patient Data");
            string[] arr;
            do
            {
                Console.WriteLine("Please Enter Patient first name then space then last name then space then age then space then priority");
                d = Convert.ToString(Console.ReadLine());
                arr = d.Split(" ");

            } while (string.IsNullOrEmpty(arr[0]) && string.IsNullOrEmpty(arr[1]) && string.IsNullOrEmpty(arr[2]) && string.IsNullOrEmpty(arr[3]));
            Patient patient = new Patient(Convert.ToInt32(arr[2]), arr[0], arr[1]);
            

    
            return (patient, Convert.ToInt32(arr[3]));
        }

    }
}

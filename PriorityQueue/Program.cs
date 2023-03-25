using Google_Calendar_API.Helper;
using JustForTest.DS;
using JustForTest.Models;
using System.Net.Mail;
namespace JustForTest
{
    public class Program
    {
        public static IPriorityQueue<Patient> PriorityQueue;
        static async Task Main(string[] args)
        {
            while (true)
            {
                if (PriorityQueue != null) break;
                Messages.DS_Priority();
                Console.WriteLine("Enter your Chioce");
                if (Char.TryParse(Console.ReadLine(), out char ch))
                {
                    switch (Char.ToUpper(ch))
                    {
                        case 'A':

                            PriorityQueue = new CircularQueuePriority<Patient>();
                            break;
                        case 'B':
                            PriorityQueue = new CircularLinkedPriority<Patient>();
                            break;
                        case 'E':
                            Environment.Exit(0);
                            break;
                        default:
                            Environment.Exit(0);
                            break;

                    }
                }
            }
            while (true)
            {
                Messages.getMessages();
                Console.WriteLine("Enter your Chioce");
                if (Char.TryParse(Console.ReadLine(),out char ch)) {
                    switch (Char.ToUpper(ch))
                    {
                        case 'A':
                            var data = Messages.getPatientDTO();
                            PriorityQueue.enQueue(data.Item1, data.Item2);
                            break;
                        case 'B':
                            PriorityQueue.deQueue();
                            break;
                        case 'C':
                            PriorityQueue.PrintAll();
                            break;
                        case 'D':
                            PriorityQueue.DeleteAll();
                            break;
                        case 'E':
                            Environment.Exit(0);
                            break;
                        default:
                            Environment.Exit(0);
                            break;
                    }
                }
                
            }
        }
    }
}

//using JustForTest.DS;
//using JustForTest.Models;

//var q = new CircularQueue<Patient>(4);

//q.enQueue(new Patient() { Age = 16, firstName = "ahmed" , lastName = "badea"},2);
//q.enQueue(new Patient() { Age = 16, firstName = "ahmed", lastName = "badea" },51);
//q.enQueue(new Patient() { Age = 16, firstName = "ahmed", lastName = "badea" }, 4);
//q.enQueue(new Patient() { Age = 16, firstName = "ahmed", lastName = "badea" }, 71);
//q.deQueue();
//q.deQueue();
//q.enQueue(new Patient() { Age = 16, firstName = "ahmed", lastName = "badea" }, 60);
//q.enQueue(new Patient() { Age = 16, firstName = "ahmed", lastName = "badea" }, 76);
//q.enQueue(new Patient() { Age = 16, firstName = "ahmed", lastName = "badea" }, 12);

//q.enQueue(22);
//q.enQueue(13);
//q.enQueue(-6);

//q.displayQueue();

//int x = q.deQueue();

//// Checking for empty queue.
//if (x != -1)
//{
//    Console.Write("Deleted value = ");
//    Console.Write(x + "\n");
//}

//x = q.deQueue();

//// Checking for empty queue.
//if (x != -1)
//{
//    Console.Write("Deleted value = ");
//    Console.Write(x + "\n");
//}

//q.displayQueue();

//q.enQueue(9);
//q.enQueue(20);
//q.enQueue(5);

//q.displayQueue();

//q.enQueue(20);
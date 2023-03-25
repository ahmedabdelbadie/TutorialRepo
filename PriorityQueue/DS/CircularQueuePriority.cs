using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForTest.DS
{


    public class CircularQueuePriority<T> : IPriorityQueue<T>
    {

        // Declaring the class variables.
        private int front, rear;

        // Declaring array list of integer type.
        private T[] queue;
        private int[] priority;

        // Constructor
        public CircularQueuePriority()
        {
            queue = new T[20];
            priority = new int[20];
            this.front = this.rear = -1;
        }
        public CircularQueuePriority(int size)
        {
            queue = new T[size];
            priority = new int[size];
            this.front = this.rear = -1;
        }
        public void enQueue(T input, int inputPriority)
        {
            if ((front == 0 && rear == queue.Length - 1) ||
              (rear == (front - 1) % (queue.Length - 1)))
            {
                Console.Write("Queue is Full");
            }

            // condition for empty queue.
            else if (front == -1)
            {
                front = 0;
                rear = 0;
                queue[0] = input;
                priority[0] = inputPriority;
            }
            else if (rear == queue.Length - 1 && front != 0)
            {

                for (int i = rear; i >= front; i--)
                {

                    if (priority[i] >= inputPriority)
                    {
                        if (i == rear)
                        {
                            queue[0] = queue[i];
                            priority[0] = priority[i];
                        }
                        else
                        {
                            queue[i + 1] = queue[i];
                            priority[i + 1] = priority[i];
                        }

                    }
                    else
                    {

                        if (i == rear)
                        {
                            queue[0] = queue[i];
                            priority[0] = priority[i];
                        }
                        else
                        {
                            queue[i + 1] = queue[i];
                            priority[i + 1] = priority[i];
                        }
                        rear = 0;
                        break;
                    }

                }
            }

            else
            {
                if (front <= rear)
                {
                    bool reach = false;
                    for (int i = rear; i >= front; i--)
                    {

                        if (priority[i] >= inputPriority)
                        {
                            queue[i + 1] = queue[i];
                            priority[i + 1] = priority[i];
                        }
                        else
                        {

                            queue[i + 1] = input;
                            priority[i + 1] = inputPriority;
                            reach = true;
                            break;
                        }

                    }
                    if (!reach)
                    {
                        queue[front] = input;
                        priority[front] = inputPriority;

                    }
                    rear += 1;
                }
                else
                {
                    bool reach = false;
                    for (int i = rear; i >= 0; i--)
                    {

                        if (priority[i] >= inputPriority)
                        {
                            queue[i + 1] = queue[i];
                            priority[i + 1] = priority[i];
                        }
                        else
                        {

                            queue[i + 1] = input;
                            priority[i + 1] = inputPriority;
                            rear += 1;
                            reach = true;
                            break;
                        }
                    }


                    if (!reach)
                    {
                        for (int j = queue.Length - 1; j >= front; j--)
                        {
                           
                            if (priority[j] >= inputPriority)
                            {
                                if (j == queue.Length - 1)
                                {
                                    queue[0] = queue[j];
                                    priority[0] = priority[j];
                                }
                                else
                                {
                                    queue[j+1] = queue[j];
                                    priority[j+1] = priority[j];
                                }
                                
                            }
                            else
                            {
                                if (j == queue.Length - 1)
                                {
                                    queue[0] = queue[j];
                                    priority[0] = priority[j];

                                }
                                else
                                {
                                    queue[j] = input;
                                    priority[j] = inputPriority;
                                }
                                rear += 1;
                                break;
                            }

                        }
                    }

                }
            }
        }
        public T deQueue()
        {
            T temp;
            if (front == -1)
            {
                Console.Write("Queue is Empty");

                return default(T);
            }

            temp = queue[front];

            if (front == rear)
            {
                front = -1;
                rear = -1;
            }

            else if (front == queue.Length - 1)
            {
                front = 0;
            }
            else
            {
                front = front + 1;
            }
            return temp;
        }
        public void PrintAll()
        {
            if (front == -1)
            {
                Console.WriteLine("Queue is Empty");
                return;
            }
            Console.WriteLine("Elements in the circular queue are: ");

            if (rear >= front)
            {
                for (int i = front; i <= rear; i++)
                {
                    Console.WriteLine($"Linked List Element Data {queue[i]} Priority {priority[i]}");
                }
            }
            else
            {
                for (int i = front; i < queue.Length - 1; i++)
                {
                    Console.WriteLine($"Linked List Element Data {queue[i]} Priority {priority[i]}");
                }
                for (int i = 0; i <= rear; i++)
                {
                    Console.WriteLine($"Linked List Element Data {queue[i]} Priority {priority[i]}");
                }
            }
        }
        public void DeleteAll()
        {
            rear = front = -1;
        }
    }
}
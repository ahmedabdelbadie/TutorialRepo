using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace JustForTest.DS
{



    public class CircularLinkedPriority<T> : IPriorityQueue<T>
    {
        public class Node<T>
        {
            public T data;
            public int Priority;
            public Node<T> next;
            
            public Node(T d,int priority)
            {
                data = d;
                this.Priority = priority;
                next = null;
            }
        }
        Node<T> head;
        public int size = 0;
        // Constructor 

        public CircularLinkedPriority()
        {
            head = null;
            this.size = 20;
        }
        public CircularLinkedPriority(int size)
        {
            head = null;
            this.size = size;
        }

        public void enQueue(T input, int inputPriority)
        {
            Node<T> current = head;
            var new_node = new Node<T>(input,inputPriority);

            if (current == null && size != 0)
            {
                new_node.next = new_node;
                head = new_node;

            }
            else if (current.Priority >= new_node.Priority)
            {
                int i = 0;
                while (current.next != head)
                {
                    if(i>=size) break;
                    current = current.next;
                    i++;
                }

                if (i > size) {
                    Console.WriteLine("priority Que is full");
                    return;
                }
                current.next = new_node;
                new_node.next = head;
                head = new_node;
            } 
            else
            {
                int i = 0;
                while (current.next != head &&
                    current.next.Priority < new_node.Priority)
                {
                    if (i >= size) break;
                    current = current.next;
                    i++;
                }

                if (i > size)
                {
                    Console.WriteLine("priority Que is full");
                    return;
                }
                new_node.next = current.next;
                current.next = new_node;
            }
        }
        public T deQueue()
        {
            Node<T> current = head;
            var data = head.data;
            while (current.next != head)
                current = current.next;

            current.next = head.next;
            head = head.next;

            return data;
        }
        public void PrintAll()
        {
            if(head == null)
            {
                Console.WriteLine("Queue is Empty");
                return;
            }
            
            Node<T> current = head;
            Console.WriteLine("Elements in the circular queue are: ");
            while (current.next != head)
            {
                Console.WriteLine($"Linked List Element Data {current.data} Priority {current.Priority}");
                current = current.next;
            }

        }
        public void DeleteAll()
        {
            head = null;
        }
    }
   
}
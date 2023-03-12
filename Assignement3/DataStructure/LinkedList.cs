using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace cSharpDataStructure.DataStructure
{
    public class Node { public int data; public Node link; }
    public class HeaderNode { public int Count; public Node link; }
    public class HeaderLinkedList
    {
        public HeaderNode head;

        public Node current;

        public void AddNode(int d)
        {
            Node n = new Node();

            n.data = d;

            if (head == null)
            {

                head = new HeaderNode();
                head.Count++;
                head.link = n;

                current = n;
            }
            else
            {
                head.Count++;
                current.link = n;
                current = n;
            }

        }
        public void print()
        {
            int i;
            HeaderNode h;
            Node p;

           

            h = head;
            if(h != null) { 
                p = h.link;
                Console.Write("<" + h.Count.ToString() + "> ");
                while (p != null)
                {
                    Console.Write("<" + p.data.ToString() +"> ");
                    p = p.link;
                }
            }
            Console.WriteLine();
           
        }
    }
}

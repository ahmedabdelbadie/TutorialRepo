using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OpenHashTable
{
    public interface IHashTable<TKey, TValue>
    {
        void Insert(TKey key, TValue value);   // Insert a <key,value> pair
        //bool Remove(TKey key);                 // Remove the value with key
        TValue Retrieve(TKey key);             // Return the value of a key
    }

    //---------------------------------------------------------------------------------------

    public class OpenHashTable<TKey, TValue> : IHashTable<TKey, TValue>
    {
        private class Node
        {
            // <key,value> pair (item)
            public TKey key;
            public TValue value;

            public Node next;

            public Node(TKey key, TValue value, Node next = null)
            {
                this.key = key;
                this.value = value;
                this.next = next;
            }
        }
        private class Point :IComparable<Point>
        {
           public int _x;
           public int _y;

            public Point(int x,int y)
            {
                _y = y;
                _x = x;
            }
            public override int GetHashCode()
            {
                //a.GetHashcode()^b.GetHashCode()
                return _x.GetHashCode() ^ _y.GetHashCode();
            }
            public override bool Equals(object point)
            {
                if(point == null && point.GetType() != typeof(Point)) return false;
                Point p = (Point)point;
                return p._x == _x && p._y == _y;
            }
            public int CompareTo(OpenHashTable<TKey, TValue>.Point? p)
            {
                int retVal = _x.CompareTo(p._x);
                if (retVal != 0)
                {
                    return retVal;
                }
                return _y.CompareTo(p._y);
            }
        }
        private class HeaderNode { public int Count; public Node next; }
        // Data Members
       
        private HeaderNode[] HT;                // Hash table array of nodes
        private int numBuckets;           // Number of buckets
        private int numItems;             // Number of items

        // Constructor
        // Creates an empty hash table

        public OpenHashTable()
        {
            numBuckets = 1;
            HT = new HeaderNode[numBuckets];
            MakeEmpty();
        }

        
        // MakeEmpty
        // Sets all buckets to empty

        public void MakeEmpty()
        {
            int i;

            for (i = 0; i < numBuckets; i++)
                HT[i] = null;
            numItems = 0;
        }
        
        // NextPrime
        // Returns the next prime number > k
        
        private int NextPrime(int k)
        {
            int i;
            bool prime = false;

            // Begin at an odd number
            if (k == 1 || k == 2)
                return k + 1;

            if (k % 2 == 0) k++;

            while (!prime)
            {
                // Divide k by odd factors
                for (i = 3; i * i < k && k % i != 0; i += 2) ;

                if (k % i != 0)
                    prime = true;
                else
                    // Increase k to the next odd number
                    k += 2;
            }
            return k;
        }
        
        // Rehash
        // Doubles the size of the hash table to the next highest prime number
        // Rehashes the items from the original hash table
        
        private void Rehash()
        {
            int i, k;
            int temp = numBuckets;       // Store the old number of buckets and
            HeaderNode[] tempHT = HT;          // hash table array

            // Determine the capacity of the new hash table
            numBuckets = NextPrime(2 * numBuckets);

            // Create the new hash table array and initialize each bucket to empty
            HT = new HeaderNode[numBuckets];
            MakeEmpty();

            // Rehash items from the old to new hash table
            for (i = 0; i < temp; i++)
            {
                HeaderNode h = tempHT[i];
                Node p = h != null ? h.next : null ;
                //Point v = new Point(1, 2).GetHashCode();

                while (p != null)
                {
                    k = p.key.GetHashCode() % numBuckets;
                    if (HT[k] == null) { HT[k] = new HeaderNode(); HT[k].next = new Node(p.key, p.value);  }
                    else { HT[k].next = new Node(p.key, p.value, HT[k].next);  }
                    numItems++; HT[k].Count++;
                    p = p.next;
                }
            }
        }
        
        // Insert
        // Insert a <key,value> into the current hash table
        // If the key is already found, an exception is thrown

        public void Insert(TKey key, TValue value)
        {
            Point _point = new Point(2,3);
            _point.Equals(new Point(6, 4));
            int i = key.GetHashCode() % numBuckets;
            HeaderNode h = HT[i];
            Node p ;
            if (h != null)
            {
                p = h.next;
                while (p != null)
                {
                    // Unsuccessful insert (key found already)
                    if (p.key.Equals(key))
                        throw new InvalidOperationException("Duplicate key");
                    else
                        p = p.next;
                }
            }
           if(h == null)
            {
                HT[i] = new HeaderNode();
            }

            HT[i].Count++;
            HT[i].next = new Node(key, value, HT[i].next);


            // Successful insert
            // Place item at the head of the list
            //HT[i] = new Node(key, value, HT[i]);
            numItems++;

            // Rehash if the average size of the buckets exceeds 5.0
            if ((double)numItems / numBuckets > 5.0)
                Rehash();
        }

        // Remove
        // Delete (if found) the <key,value> with the given key
        // Return true if successful, false otherwise
        
        public bool Remove(TKey key)
        {
            int i = key.GetHashCode() % numBuckets;
            HeaderNode h = HT[i];
            Node p;

            if (h == null)
                return false;
            else
            // Successful remove of the first item in a bucket
            if (h.next.key.Equals(key))
            {
                HT[i].next = HT[i].next.next;
                HT[i].Count--;
                numItems--;
                return true;
            }
            else
            {
                p=h.next;
                while (p.next != null)
                {
                    // Successful remove (<key,value> found and deleted)
                    if (p.next.key.Equals(key))
                    {
                        p.next = p.next.next;
                        HT[i].Count--;
                        numItems--;
                        return true;
                    }
                    else
                        p = p.next;
                }

            }

            // Unsuccessful remove (key not found)
            return false;
        }
        
        // Retrieve
        // Returns (if found) the value of the given key
        // If the key is not found, an exception is thrown

        public TValue Retrieve(TKey key)
        {
            int i = key.GetHashCode() % numBuckets;
            HeaderNode h = HT[i];
            Node p;
            if(h != null)
            {
                p = h.next;
                while (p != null)
                {
                    // Successful retrieval (value found and returned)
                    if (p.key.Equals(key))
                        return p.value;
                    else
                        p = p.next;
                }
            }
            throw new InvalidOperationException("Key not found");
        }

        // Print
        // Prints the hash table entries, one line per bucket

        public void Print()
        {
            int i;

            HeaderNode h ;
            Node p;
            for (i = 0; i < numBuckets; i++)
            {
                Console.Write(i.ToString().PadLeft(2) + ": ");

                h = HT[i];
                if(h != null)
                {
                    Console.Write($"Count {h.Count.ToString().PadLeft(2)} : ");

                    p = h.next;
                    while (p != null)
                    {
                        Console.Write("<" + p.key.ToString() + "," + p.value.ToString() + "> ");
                        p = p.next;
                    }
                }
                Console.WriteLine();
            }
        }

    }

    //---------------------------------------------------------------------------------------

    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        HashTable<int, int> H = new HashTable<int, int>();

    //        Console.WriteLine("Executing Open Hash Table");
    //        Console.WriteLine();

    //        for (int i = 0; i < 100; i++)
    //            H.Insert(i, i);

    //        H.Print();

    //        for (int i = 0; i < 100; i += 2)
    //            H.Remove(i);

    //        H.Print();

    //        Console.ReadKey();
    //    }
    //}
}

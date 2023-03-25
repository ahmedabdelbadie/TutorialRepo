using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustForTest.DS
{
    public interface IPriorityQueue<T>
    {
        void enQueue(T input, int inputPriority);
        T deQueue();
        void PrintAll();
        void DeleteAll();
    }
}

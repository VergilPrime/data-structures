using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleStackQueue
{
    class Queue
    {
        public Stack<int> S1 { get; set; }
        public Stack<int> S2 { get; set; }

        public int Dequeue(int value)
        {
            while (S1.Count != 0)
            {
                S2.Push(S1.Pop());
            }
            int Drop = S2.Pop();
            while(S2.Count != 0)
            {
                S1.Push(S2.Pop());
            }
            return Drop;
        }

        public void Enqueue(int value)
        {
            S1.Push(value);
        }

        public void Peek(int value)
        {
            S1.Peek();
        }
    }
}

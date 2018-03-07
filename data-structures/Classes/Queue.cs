using System;
using System.Collections.Generic;
using System.Text;

namespace datastructures.Classes
{
    public class Queue
    {
        public Node Head { get; set; }
        public Node Runner { get; set; }

        public void NQ(int Val)
        {
            Head = new Node { Value = Val, Next = Head };
        }

        public int Peek()
        {
            Runner = Head;
            while (Runner.Next!= null)
            {
                Runner = Runner.Next;
            }
            return Runner.Value;
        }

        public int DQ()
        {
            Runner = Head;
            while (Runner.Next.Next != null)
            {
                Runner = Runner.Next;
            }
            int result = Runner.Next.Value;
            Runner.Next = null;
            return result;

        }
    }
}

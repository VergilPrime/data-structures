using System;
using System.Collections.Generic;
using System.Text;

namespace datastructures.Classes
{
    public class CQueue
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
            int result;
            if (Runner.Next == null)
            {
                result = Runner.Value;
                Runner = null;
                return result;
            }
            while (Runner.Next.Next != null)
            {
                Runner = Runner.Next;
            }
            result = Runner.Next.Value;
            Runner.Next = null;
            return result;

        }
    }
}

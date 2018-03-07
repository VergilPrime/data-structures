using System;
using System.Collections.Generic;
using System.Text;

namespace datastructures.Classes
{
    class Stack
    {
        public Node Head { get; set; }
        public Node Runner { get; set; }

        public void Push(int Val)
        {
            Head = new Node { Value = Val, Next = Head };
        }

        public int Peek()
        {
            return Head.Value;
        }

        public int Pop()
        {
            int result = Head.Value;
            Head = Head.Next;
            return result;
        }
    }
}

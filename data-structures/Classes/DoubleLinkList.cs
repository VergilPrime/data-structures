using System;
using System.Collections.Generic;
using System.Text;

namespace datastructures.Classes
{
    public class DoubleLinkList
    {
        public DoubleNode Head { get; set; }

        public DoubleNode Runner { get; set; }

        public DoubleLinkList()
        {
            Head = new DoubleNode { Value = 0, Prev = null, Next = null };
            Runner = Head;
        }

        public DoubleLinkList(int value)
        {
            Head = new DoubleNode { Value = value, Prev = null, Next = null };
            Runner = Head;
        }

        public void AddFirst(int value)
        {
            Runner = Head;
            Head = new DoubleNode { Prev = null, Value = value, Next = Head };

        }

        public void AddLast(int value)
        {
            Runner = Head;
            while(Runner.Next != null)
            {
                Runner = Runner.Next;
            }
            Runner.Next = new DoubleNode { Prev = Runner, Value = value, Next = null };
            Runner = Head;
        }

        public void AddBefore(int value,int target)
        {
            Runner = Head;
            while (Runner.Next != null)
            {
                if(Runner.Value == target)
                {
                    DoubleNode node = new DoubleNode { Prev = Runner.Prev, Value = value, Next = Runner };
                    Runner.Prev.Next = node;
                    Runner.Prev = node;
                }
                Runner = Runner.Next;
            }
            Runner = Head;
        }

        public void AddAfter(int value, int target)
        {
            Runner = Head;
            while (Runner.Next != null)
            {
                if (Runner.Value == target)
                {
                    DoubleNode node = new DoubleNode { Prev = Runner, Value = value, Next = Runner.Next };
                    Runner.Next.Prev = node;
                    Runner.Next = node;
                }
                Runner = Runner.Next;
            }
            Runner = Head;
        }

        public void RemoveNode(int target)
        {
            Runner = Head;
            Runner = Runner.Next;
            while (Head.Value == target)
            {
                Head = Head.Next;
                Head.Prev = null;
                Runner.Next = null;
                Runner = Head;
            }
            while(Runner.Next != null)
            {
                if(Runner.Value == target)
                {
                    Runner.Next.Prev = Runner.Prev;
                    Runner.Prev.Next = Runner.Next;
                    Runner.Next = null;
                    Runner.Prev = null;
                }
                Runner = Head;
            }
            Runner = Head;
        }




    }
}

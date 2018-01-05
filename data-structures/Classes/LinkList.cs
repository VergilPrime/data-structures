using System;
using System.Collections.Generic;
using datastructures;
using Newtonsoft.Json;

namespace datastructures.Classes
{
    public class LinkList
    {
        public Node Head { get; set; }

        //Thanks Andre for letting me read off his stuff after I accidentally deleted mine.
        //Thanks to Amanda as cause I had an infinite loop for a while.
        public void AddBefore(int value, int target)
        {
            Node R = Head;

            if(R.Value == target)
            {
                Head = new Node { Value = value, Next = Head };
                R = Head.Next;
            }
            while(R.Next != null)
            {
                if (R.Next.Value == target)
                {
                    R.Next = new Node { Value = value , Next = R.Next};
                    R = R.Next;
                }
                R = R.Next;
            }

        }

        public void AddAfter(int value, int target)
        {
            Node R = Head;

            for (int i = 0; R.Next != null; i++)
            {
                R = R.Next;
                if(R.Value == target)
                {
                    Node N = R.Next;
                    if (R.Next != null)
                    {
                        R.Next.Next = null;
                    }
                    R.Next = new Node
                    {
                        Value = value,
                        Next = N
                    };
                }
            }
        }

        public void AddFirst(int value)
        {
            Node N = new Node { Value = value, Next = Head };

            Head = N;
        }

        public void AddLast(int value)
        {
            if (Head == null)
            {
                Head = new Node();
                Head.Value = value;
            }
            else
            {
                Node R = Head;

                while (R.Next != null)
                {
                    R = R.Next;
                }

                R.Next = new Node();
                R.Next.Value = value;

            }
            }

        public Node Middle()
        {
            Node R1 = this.Head;
            Node R2 = this.Head;

            int counter = 0;

            while(R1.Next != null)
            {
                counter++;
                R1 = R1.Next;
                if(counter % 2 == 0)
                {
                    R2 = R2.Next;
                }
                if(R1.Next == null)
                {
                    return R2;
                }
            }
            return R2;
        }
    }
}

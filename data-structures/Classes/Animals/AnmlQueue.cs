using System;
using System.Collections.Generic;
using System.Text;

namespace datastructures.Classes.Animals
{
    public class AnmlQueue
    {
        public Anml Head { get; set; }
        public Anml Runner { get; set; }

        public void NQ(int type, int dob)
        {
            Anml OldHead = Head;
            Head = new Anml ( type, dob );
            Head.Next = OldHead;
        }

        public Anml Peek()
        {
            Runner = Head;
            while (Runner.Next!= null)
            {
                Runner = Runner.Next;
            }
            return Head;
        }

        public Anml DQ()
        {
            Runner = Head;
            while (Runner.Next.Next != null)
            {
                Runner = Runner.Next;
            }
            Anml returned = Runner.Next;
            Runner.Next = null;
            return returned;
        }
    }
}

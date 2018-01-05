using System;
using System.Collections.Generic;
using System.Text;

namespace datastructures.Classes
{
    public class DoubleLinkList
    {
        public DoubleNode Head { get; set; }

        public void Remove(int input)
        {
            DoubleNode R = Head;
            while (R.Next != null)
            {
                if(R.Value == input)
                {
                    R.Prev.Next = null;
                    R.Next.Prev = null;
                    R.Prev = null;
                    R.Next = null;
                }
                R = R.Next;
            }
        }

        public void AddBefore(int input,int target)
        {
            DoubleNode R = Head;
            while (R.Next != null)
            {
                if (R.Next.Value == input)
                {

                    R.Next = new DoubleNode { Prev = R, Value = input, Next = R.Next };
                }
            }
        }
    }
}

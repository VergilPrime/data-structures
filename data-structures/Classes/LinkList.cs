using System;
using System.Collections.Generic;
using System.Text;

namespace datastructures.Classes
{
    public class LinkList
    {
        public Node Head { get; set; }

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

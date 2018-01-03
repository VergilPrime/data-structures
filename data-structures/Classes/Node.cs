using System;
using System.Collections.Generic;
using System.Text;

namespace datastructures.Classes
{
    public class Node
    {
        public int Value { get; set; }

        public Node Next { get; set; }

        public Node(int value)
        {
            Value = value;
        }

        public Node(int value, Node next)
        {
            Value = value;
            Next = next;

        }
    }
}

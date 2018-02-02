using System;
using System.Collections.Generic;

namespace Trees
{
    internal class TreeNode
    {
        public TreeNode Left { get; set; }
        public int Val { get; set; }
        public TreeNode Right { get; set; }

        public void InOrder()
        {
            if(this != null)
            {
                if(Left != null)
                {
                    Left.InOrder();
                }
                
                Console.Write(Val + " ");

                if(Right != null)
                {
                    Right.InOrder();
                }
            }
        }

        public void PreOrder()
        {
            if (this != null)
            {
                Console.Write(Val + " ");

                if (Left != null)
                {
                    Left.InOrder();
                }

                if (Right != null)
                {
                    Right.InOrder();
                }
            }
        }

        public void PostOrder()
        {
            if (this != null)
            {
                if (Left != null)
                {
                    Left.InOrder();
                }

                if (Right != null)
                {
                    Right.InOrder();
                }

                Console.Write(Val + " ");
            }
        }

        public void BreadthFirst(Queue<TreeNode> Q)
        {
            Console.Write(Val + " ");
            if (this.Left != null)
            {
                Q.Enqueue(this.Left);
            }
            if (this.Right != null)
            {
                Q.Enqueue(this.Right);
            }
            if(Q.Count > 0)
            {
                Q.Dequeue().BreadthFirst(Q);
            }
        }

        public void AddToBST(int i)
        {
            if (this == null)
            {
                this.Val = i;
            }
            else if(Val == i)
            {
                return;
            }
            else if(Val > i)
            {
                this.Left.AddToBST(i);
            }
            else
            {
                this.Right.AddToBST(i);
            }
        }
    }
}
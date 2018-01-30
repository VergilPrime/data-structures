using System;
using System.Collections.Generic;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode rootBall = new TreeNode()
            {
                Left = new TreeNode()
                {
                    Left = new TreeNode()
                    {
                        Val = 15
                    },
                    Val = 123,
                    Right = new TreeNode()
                    {
                        Val = 33
                    }
                },
                Val = 41,
                Right = new TreeNode()
                {
                    Val = 32
                }
            }; // End of rootBall

            rootBall.InOrder();

            Console.WriteLine("");
            Console.WriteLine("Maximum is " + FindMax(rootBall) + ".");
            Console.WriteLine("Minimum is " + FindMin(rootBall) + ".");

            Console.ReadLine();

        }

        static public int FindMax(TreeNode node)
        {
            int Max = node.Val;
            if(node.Left != null)
            {
                int LMax = FindMax(node.Left);
                if (LMax > Max) Max = LMax;
            }
            if (node.Right != null)
            {
                int RMax = FindMax(node.Right);
                if (RMax > Max) Max = RMax;
            }
            return (Max);
        }

        static public int FindMin(TreeNode node)
        {
            int Min = node.Val;
            if (node.Left != null)
            {
                int LMin = FindMin(node.Left);
                if (LMin < Min) Min = LMin;
            }
            if (node.Right != null)
            {
                int RMin = FindMin(node.Right);
                if (RMin < Min) Min = RMin;
            }
            return (Min);
        }
    }
}

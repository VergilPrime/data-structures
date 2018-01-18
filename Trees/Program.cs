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
                        Val = "Hello"
                    },
                    Val = "my",
                    Right = new TreeNode()
                    {
                        Val = "Name"
                    }
                },
                Val = "is",
                Right = new TreeNode()
                {
                    Val = "Roger."
                }
            }; // End of rootBall

            Console.WriteLine("Press enter to try InOrder().");
            Console.ReadLine();

            rootBall.InOrder();

            Console.WriteLine();
            Console.WriteLine("Now press enter to try PreOrder().");
            Console.ReadLine();

            rootBall.PreOrder();

            Console.WriteLine();
            Console.WriteLine("Now press enter to try PostOrder().");
            Console.ReadLine();

            rootBall.PostOrder();

            Console.WriteLine();
            Console.WriteLine("Now press enter to try BreadthFirst().");
            Console.ReadLine();

            rootBall.BreadthFirst(new Queue<TreeNode>());

            Console.WriteLine();
            Console.WriteLine("Now it's all scrambled!");
            Console.ReadLine();

        }
    }
}

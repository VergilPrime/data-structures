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
            Console.WriteLine("Parent of 15 is...");
            Console.WriteLine(findParentOf(rootBall,15).Val);

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

        static public TreeNode findParentOf(TreeNode treenode, int childval)
        {
            if(treenode == null)
            {
                return null;
            }
            if(treenode.Left != null)
            {
                if (treenode.Left.Val == childval)
                {
                    return treenode;
                }
                else
                {
                    TreeNode lefttry = findParentOf(treenode.Left, childval);
                    if (lefttry != null)
                    {
                        return (lefttry);
                    }
                }
            }
            if(treenode.Right != null)
            {
                if(treenode.Right.Val == childval)
                {
                    return treenode;
                }
                else
                {
                    TreeNode righttry = findParentOf(treenode.Right, childval);
                    return (righttry);
                }
            }
            
            return findParentOf(treenode.Right, childval);
        }

        static public TreeNode SwitchLeaves(TreeNode treenode,int i1, int i2)
        {
            TreeNode P1 = findParentOf(treenode, i1);
            TreeNode P2 = findParentOf(treenode, i2);
            TreeNode N1;
            TreeNode N2;
            if(P1.Left.Val == i1)
            {
                N1 = P1.Left;
            }
            else
            {
                N1 = P1.Right;
            }
            if (P2.Left.Val == i1)
            {
                N2 = P2.Left;
                P2.Left = N1;
            }
            else
            {
                N2 = P2.Right;
                P2.Right = N1;
            }
            if (P1.Left.Val == i1)
            {
                P1.Left = N2;
            }
            else
            {
                P1.Right = N2;
            }
            return treenode;
        }
    }
}

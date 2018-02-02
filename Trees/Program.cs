using System;
using System.Collections.Generic;
using Newtonsoft;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 4, 5, 7, 10, 22, 31, 40 };

            TreeNode root = ArrayToBinaryTree(array);

            Console.WriteLine("Tree looks like:");
            Console.WriteLine("");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(root));
            Console.WriteLine("");
            Console.WriteLine("In English that's:");
            Console.WriteLine("");
            root.BreadthFirst(new Queue<TreeNode>());
            Console.WriteLine("");
            Console.WriteLine("");
            //Console.WriteLine("Sorted that looks like:");
            //Console.WriteLine("");
            //ArrayToBinarySearchTree(array).BreadthFirst(new Queue<TreeNode>());
            Console.WriteLine("New tree looks like:");
            Console.WriteLine("");
            root = new TreeNode() { Val = 5 };
            root.AddToBST(4);
            root.AddToBST(1);
            root.AddToBST(2);
            root.AddToBST(40);
            root.AddToBST(31);
            root.AddToBST(7);
            root.AddToBST(10);
            root.AddToBST(22);
            Console.WriteLine("");
            root.BreadthFirst(new Queue<TreeNode>());
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

        static public TreeNode FindParentOf(TreeNode treenode, int childval)
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
                    TreeNode lefttry = FindParentOf(treenode.Left, childval);
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
                    TreeNode righttry = FindParentOf(treenode.Right, childval);
                    return (righttry);
                }
            }
            
            return FindParentOf(treenode.Right, childval);
        }

        static public TreeNode SwitchLeaves(TreeNode treenode,int i1, int i2)
        {
            TreeNode P1 = FindParentOf(treenode, i1);
            TreeNode P2 = FindParentOf(treenode, i2);
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

        public static TreeNode ArrayToBinaryTree(int[] intarray )
        {
            List<TreeNode> nodelist = new List<TreeNode>();

            for (int i = 0; i < intarray.Length; i++)
            {
                nodelist.Add(new TreeNode() { Val = intarray[i] });
            }

            for (int i = nodelist.Count - 1; i >= 0; i--)
            {
                int childLIndex = i * 2 + 1;
                int childRIndex = childLIndex + 1;
                if (childLIndex < nodelist.Count)
                {
                    nodelist[i].Left = nodelist[childLIndex];
                }
                if (childRIndex < nodelist.Count)
                {
                    nodelist[i].Right = nodelist[childRIndex];
                }
            }

            return nodelist[0];

        }

        public static TreeNode ArrayToBinarySearchTree(int[] intarray)
        {
            Array.Sort(intarray);

            double arraysize = intarray.Length / 2;

            int centerIndex = (int)Math.Ceiling(arraysize);

            int[] L = new int[centerIndex];
            int[] R = new int[centerIndex];
            for (int i = 0; i < centerIndex; i++)
            {
                L[i] = intarray[i];
                R[i] = intarray[i + centerIndex];
            }

            TreeNode newnode = new TreeNode()
            {
                Val = centerIndex,
                Left = ArrayToBinarySearchTree(L),
                Right = ArrayToBinarySearchTree(R)
            };

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(newnode));

            return newnode;
        }
    }
}
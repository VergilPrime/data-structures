using System;
using System.Collections.Generic;
using Newtonsoft;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 8, 12, 4, 32, 41, 14, 2, 5 };

            TreeNode root = ArrayToBinaryTree(array);

            Console.WriteLine("Tree looks like:");
            Console.WriteLine("");
            root.BreadthFirst(new Queue<TreeNode>());
            Console.WriteLine("");
            Console.WriteLine("Sorted that looks like:");
            Console.WriteLine("");
            root = ArrayToBinarySearchTree(array);
            root.BreadthFirst(new Queue<TreeNode>());
            Console.WriteLine("");
            Console.WriteLine("New tree looks like:");
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
            Console.WriteLine("");
            Console.WriteLine("That's not nearly as helpful as I imagined. I suppose use debug to see it in a more managable format?");
            root = DeleteNode(root,10);
            Console.WriteLine("");
            root.BreadthFirst(new Queue<TreeNode>());
            Console.WriteLine("");
            Console.WriteLine("And now the 10 should be missing.");
            //Console.WriteLine("");
            //Console.WriteLine("The total length of this tree from head to head is:");
            //Console.WriteLine("");
            //Console.WriteLine(TotalLength(root));
            Console.WriteLine("");

            Console.ReadLine();
        }

        static public int FindMax(TreeNode node)
        {
            int Max = node.Val;
            if (node.Left != null)
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
            if (treenode == null)
            {
                return null;
            }
            if (treenode.Left != null)
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
            if (treenode.Right != null)
            {
                if (treenode.Right.Val == childval)
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

        static public TreeNode SwitchLeaves(TreeNode treenode, int i1, int i2)
        {
            TreeNode P1 = FindParentOf(treenode, i1);
            TreeNode P2 = FindParentOf(treenode, i2);
            TreeNode N1;
            TreeNode N2;
            if (P1.Left.Val == i1)
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

        public static TreeNode ArrayToBinaryTree(int[] intarray)
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

        public static TreeNode ArrayToBinarySearchTree(int[] input)
        {
            if (input.Length == 1)
            {
                return new TreeNode() { Val = input[0] };
            }

            Array.Sort(input);

            int centerIndex;

            if (input.Length % 2 == 1)
            {
                centerIndex = input.Length / 2 + 1;
            }
            else
            {
                centerIndex = input.Length / 2;
            }

            TreeNode node = new TreeNode() { Val = input[centerIndex] };

            int[] left = new int[centerIndex];

            int j = 0;

            int[] right = new int[centerIndex];

            for (int i = 0; i < input.Length; i++)
            {
                if (i < centerIndex)
                {
                    left[i] = input[i];
                }
                else if (i > centerIndex)
                {
                    right[j] = input[i];
                    j++;
                }
            }

            node.Left = ArrayToBinarySearchTree(left);

            node.Right = ArrayToBinarySearchTree(right);

            return node;
        }

        public static TreeNode DeleteNode(TreeNode input, int val)
        {
            if(input.Val == val)
            {
                if(input.Left != null)
                {
                    if(input.Right != null)
                    {
                        TreeNode limb = input.Right;
                        input = input.Left;
                        if(input.Right == null)
                        {
                            input.Right = limb;
                        }
                        else
                        {
                            AddBranch(limb, input.Right);
                        }
                    }
                    else
                    {
                        input = input.Left;
                    }
                }
                else if(input.Right != null)
                {
                    input = input.Right;
                }
                else
                {
                    input = null;
                }
            }

            if(input.Left != null)
            {
                input.Left = DeleteNode(input.Left, val);
            }

            if (input.Right != null)
            {
                input.Right = DeleteNode(input.Right, val);
            }
            return input;
        }

        static public TreeNode FindBranch(TreeNode node, int del)
        {
            if (node.Val == del)
            {
                return node;
            }
            else if (del < node.Val)
            {
                if (node.Left != null)
                {
                    return FindBranch(node.Left, del);
                }
            }
            else
            {
                if (node.Right != null)
                {
                    return FindBranch(node.Right, del);
                }
            }

            return null;
        }

        static public TreeNode AddBranch(TreeNode newlimb, TreeNode tree)
        {
            if (newlimb.Val <= tree.Val)
            {
                if (tree.Left != null)
                {
                    tree.Left = AddBranch(newlimb, tree.Left);
                }
                else
                {
                    tree.Left = newlimb;
                }
            }
            else
            {
                if (tree.Right != null)
                {
                    tree.Right = AddBranch(newlimb, tree.Right);
                }
                else
                {
                    tree.Right = newlimb;
                }
            }

            return tree;
        }

        public static TreeNode DeleteBranch(TreeNode node, int del)
        {
            if (node.Val == del)
            {
                return null;
            }
            else if (del < node.Val)
            {
                if (node.Left != null)
                {
                    return DeleteBranch(node.Left, del);
                }
            }
            else
            {
                if (node.Right != null)
                {
                    return DeleteBranch(node.Right, del);
                }
            }

            return null;
        }

        public static int TotalLength(TreeNode node)
        {
            int length = 1;

            int leftLength = 0;
            int rightLength = 0;

            if (node.Left != null)
            {
                leftLength = TotalLength(node.Left, length);
            }

            if (node.Right != null)
            {
                rightLength = TotalLength(node.Right, length);
            }

            if (leftLength >= rightLength)
            {
                return (leftLength);
            }
            else
            {
                return (rightLength);
            }
        }

        public static int TotalLength(TreeNode node, int length)
        {
            length++;

            int leftLength = length;
            int rightLength = length;

            if (node.Left != null)
            {
                leftLength = TotalLength(node.Left, length);
            }

            if (node.Right != null)
            {
                rightLength = TotalLength(node.Right, length);
            }

            if (leftLength >= rightLength)
            {
                return (leftLength);
            }
            else
            {
                return (rightLength);
            }
        }
    }
}
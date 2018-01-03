using System;
using Xunit;
using datastructures.Classes;


namespace XUnitTesting
{
    public class UnitTest1
    {
        [Fact]
        public void TestMiddle()
        {
            LinkList list = new LinkList();
            list.Head = new Node(0);
            list.Head.Next = new Node(1);
            list.Head.Next.Next = new Node(2);
            list.Head.Next.Next.Next = new Node(3);
            list.Head.Next.Next.Next.Next = new Node(4);
            list.Head.Next.Next.Next.Next.Next = new Node(5);
            Node testMiddle = list.Middle();
            Assert.Equal(2, testMiddle.Value);

        }
    }
}
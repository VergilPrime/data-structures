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
            LinkList list = new LinkList
            {
                Head = new Node
                {
                    Value = 0,
                    Next = new Node
                    {
                        Value = 1,
                        Next = new Node
                        {
                            Value = 2
                        }
                    }
                }
            };

            Node testMiddle = list.Middle();
            Assert.Equal(12, testMiddle.Value);

            list.AddAfter(3, 1);
            list.AddLast(4);

            testMiddle = list.Middle();
            Assert.Equal(4, testMiddle.Value);


        }
    }
}
using System;
using datastructures.Classes;
using Newtonsoft.Json;

namespace datastructures
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkList TestList = new LinkList();

            for(int i = 1; i < 10; i++) TestList.AddLast(i);

            Console.WriteLine("Initial List Starring AddLast");
            JsonPreview(TestList);

            TestList.AddBefore(0, 1);
            TestList.AddAfter(11, 9);

            Divider();

            Console.WriteLine("Introducing AddBefore and AddAfter");
            JsonPreview(TestList);

            TestList.AddBefore(0, 1);
            TestList.AddAfter(10, 9);

            Divider();

            Console.WriteLine("AddBefore and AddAfter still.");
            JsonPreview(TestList);

            //TestList.AddFirst(-1);
            TestList.AddLast(12);

            Divider();

            Console.WriteLine("Suddenly AddFirst and AddLast");
            JsonPreview(TestList);



        }

        public static void JsonPreview(LinkList input)
        {
            Console.WriteLine(JsonConvert.SerializeObject(input, Formatting.Indented));

            Console.ReadLine();
        }

        private static void Divider() =>
            Console.WriteLine("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
    }
}

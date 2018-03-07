using System;
using datastructures.Classes;
using Newtonsoft.Json;
using datastructures.Classes;
using System.Collections.Generic;
using datastructures.Classes.Animals;

namespace datastructures
{
    public class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 4, 1, 6, 2, 7, 2, 73, 7, 7, 3, 4, 1 };
            CQueue customQueue = new CQueue();
            CStack customStack = new CStack();

            for (int i = 0; i < array.Length; i++)
            {
                customQueue.NQ(array[i]);
                customStack.Push(array[i]);
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(customQueue.DQ());
            }
            Console.WriteLine();
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(customStack.Pop());
            }
            Console.WriteLine();
            Console.ReadLine();

        }

        static bool ParensCheck(string input)
        {
            Stack<char> S = new Stack<char>();

            for (int i = input.Length / 2; i < input.Length; i++)
            {
                S.Push(input[i]);
            }

            for (int i = 0; i < input.Length / 2; i++)
            {
                char A = input[i];
                char B = S.Pop();

                Console.WriteLine("" + A + B);
                if ((A == '(' && B != ')' ) || ( A == '{' && B != '}'))
                {
                    return false;
                }
            }
            return true;
        }

        public static void JsonPreview(Anml input)
        {
            Console.WriteLine(JsonConvert.SerializeObject(input, Formatting.Indented));

            Console.ReadLine();
        }

        public static int addPet(AnmlQueue Catlist, AnmlQueue Doglist, int type, int StopWatch)
        {
            switch (type)
            {
                case 1:
                    Catlist.NQ(2, StopWatch);
                    break;
                case 2:
                    Doglist.NQ(1, StopWatch);
                    break;
            }
            StopWatch++;
            return StopWatch;
        }

        public static Anml getPet(AnmlQueue Catlist, AnmlQueue Doglist, int type)
        {
            switch (type)
            {
                case 1:
                    return Catlist.DQ();
                case 2:
                    return Doglist.DQ();
                case 0:
                default:
                    int DogDOB = Doglist.Peek().DOB;
                    int CatDOB = Catlist.Peek().DOB;
                    if(DogDOB < CatDOB)
                    {
                        return Doglist.DQ();
                    }
                    else
                    {
                        return Catlist.DQ();
                    }
            }
        }

        private static void Divider() =>
            Console.WriteLine("=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=");
    }
}

using System;
using datastructures.Classes;
using Newtonsoft.Json;
using datastructures.Classes.Animals;

namespace datastructures
{
    public class Program
    {
        static void Main(string[] args)
        {
            int StopWatch = 0;

            AnmlQueue Doglist = new AnmlQueue();
            AnmlQueue Catlist = new AnmlQueue();

            StopWatch = addPet(Catlist, Doglist, 1, StopWatch);
            StopWatch = addPet(Catlist, Doglist, 1, StopWatch);
            StopWatch = addPet(Catlist, Doglist, 2, StopWatch);
            StopWatch = addPet(Catlist, Doglist, 2, StopWatch);
            StopWatch = addPet(Catlist, Doglist, 1, StopWatch);
            StopWatch = addPet(Catlist, Doglist, 2, StopWatch);
            StopWatch = addPet(Catlist, Doglist, 1, StopWatch);

            //Console.WriteLine("Catlist");
            //JsonPreview(Catlist);
            //Console.WriteLine("Doglist");
            //JsonPreview(Doglist);

            Console.Write("Type 1 = Cat. Type 2 = Dog.");
            JsonPreview(getPet(Catlist, Doglist, 0));
            JsonPreview(getPet(Catlist, Doglist, 2));
            JsonPreview(getPet(Catlist, Doglist, 2));
            JsonPreview(getPet(Catlist, Doglist, 0));

            Console.Read();

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

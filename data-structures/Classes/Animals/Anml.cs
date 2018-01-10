using System;
using System.Collections.Generic;
using System.Text;

namespace datastructures.Classes.Animals
{
    public class Anml
    {
        public int Type { get; set; }

        public int DOB { get; set; }

        public Anml Next { get; set; }

        public Anml(int type, int dob)
        {
            Type = type;
            DOB = dob;
        }
    }
}

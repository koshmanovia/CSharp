using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDistanceToTheSun
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong inches;
            ulong miles = 93000000;
            ulong metres;

            inches = miles * 5280 * 12;
            metres = miles * 1609;

            Console.WriteLine("The Distance to the Sun " + inches + " inches or " + metres + " metres");
            Console.ReadKey();
            
        }
    }
}

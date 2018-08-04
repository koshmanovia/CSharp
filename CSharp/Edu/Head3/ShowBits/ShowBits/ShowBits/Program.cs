using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowBits
{
    class Program
    {
        static void Main(string[] args)
        {
            byte val = 255
                 
                 ;
            int t = 128;

            for (; t > 0; t = t/2 )
            {
                if ((val & t) != 0) Console.Write("1 ");
                else Console.Write("0 ");

            }
            Console.ReadKey();
        }
    }
}

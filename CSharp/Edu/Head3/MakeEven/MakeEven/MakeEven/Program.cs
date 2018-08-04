using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakeEven
{
    class Program
    {
        static void Main(string[] args)
        {
            ushort num , i ;
            for(i = 1; i < 21; i++)
            {
                num = i;
                Console.WriteLine("num: " + num);
                num = (ushort)(num & 0xFFFE);
                Console.WriteLine("После сброса младшего разряда " + num + "\n");
            }
            Console.ReadKey();
        }
    }
}

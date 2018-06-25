using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinCosTan
{
    class Program
    {
        static void Main(string[] args)
        {
            for (Double theta = 0.1; theta <= 1.0; theta = theta + 0.1)
            {
                Console.WriteLine("sin " + theta + " = " + Math.Sin(theta));
                Console.WriteLine("cos " + theta + " = " + Math.Cos(theta));
                Console.WriteLine("tg  " + theta + " =" +
                    " " + Math.Tan(theta));
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }

}



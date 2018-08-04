using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ifelse
{
    class Program
    {
        static void Main(string[] args)
        {
            int a=0, b =0, c=0;

            for (int i = 1; i < 4; i++)
            {
                    Console.WriteLine("Введите "+ i +" число");
                    if (i == 1)  a = Convert.ToInt32(Console.ReadLine());                         
                        else
                    if (i == 2)  b = Convert.ToInt32(Console.ReadLine());                        
                        else
                    if (i == 3)  c = Convert.ToInt32(Console.ReadLine());                         
                        else
                        Console.WriteLine("WARNING! LOOP IS BREAK! CALL 911! ");
            }
            
            Console.Write(a +" ");
            Console.Write(b + " ");
            Console.Write(c);

            Console.ReadKey();

        }
    }
}

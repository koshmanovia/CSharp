using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TestConstant
{
    class Program
    {
        static void Main(string[] args)
        {
            //Example 1
            String Test = "Test";
           {
                Console.WriteLine("\a{0}\n", Test); //Вывод со звуковым сигналом
                Thread.Sleep(500);
           }

            //Example 2
            Console.WriteLine(" \"словосочетание в ковычках\" словосочетание без ковычек\n"); //тест ковычек в выводе
          
            


            //Example 3 
            Console.WriteLine("Пример\n \nперевода\n \nстрок\n");
            Console.WriteLine("Пример \tтабуляции\n");

            //Example 4
            Console.WriteLine(@"Вывод буквального
Строкового Литерала

С табуляцией например тут же
1   2   3   4
5   6   7   8 

Прямая речь: ""Что-то тут сказали.""");


            Console.ReadLine();


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotCompatibleTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            String o = " после присваивания ", s1 = " -- с потерей данных ", s2 = " -- без потери данных ";
            double x = 10.0, y = 3.0;
            byte b;
            int i;
            char ch;
            uint u =32000;
            short s;
            long l;


            //Приведение типа double к типу int с потерей данных -- дробная часть теряется
            i = (int)(x / y);
            Console.WriteLine("Целочисленный результат деления х / у: " + i + "\n");

            //Приведение типа int к типу byte без потери данных
            i = 255;
            b = (byte)i;
            Console.Write("b" + o + "255: " + b + s2 + "\n");
            //Приведение типа int к типу byte c потерей данных
            i = 257;
            b = (byte)i;
            Console.WriteLine("b" + o + "257: " + b + s1 + "\n");

            //Приведение типа uint к типу short без потери данных
            s = (short) u;
            Console.Write("s" + o + "32000: " + s + s2 + "\n");
            //Приведение типа uint к типу short c потерей данных
            u = 64000;
            s = (short)u;
            Console.WriteLine("s" + o + "64000: " +s + s1 + "\n");

            //Приведение типа long к типу uint без потери данных
            l = 64000;
            u = (uint)l;
            Console.Write("s" + o + "64000: " + u + s2 + "\n");
            //Приведение типа uint к типу short c потерей данных
            l = -12;
            u = (uint)l;
            Console.WriteLine("s" + o + "-12: " + u + s1 + "\n");

            //Приведение типа int к типу char
            b = 88;
            ch = (char) b;
            Console.WriteLine("ch после присваивания 88: {0}", ch);

            Console.ReadKey();
        }

    }
}

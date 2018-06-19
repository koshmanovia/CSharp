using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division
{
    class Program
    {
        static void Main(string[] args)
        {
            int i, j , d = 0;
            Console.Write("Введите делимое: ");
            j = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Введите делитель: ");
            i = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (i == 0)
                Console.WriteLine("Делитель равен 0, дальнейшие вычисления невозможны!");
            else
                d = j / i;
                Console.Write("Частность равна: " + d);
            Console.Read();

        
        }
    }
}

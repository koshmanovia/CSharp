using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplicitlyTypedVar
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Неявно типизированы, но автоматом отнесены к типу double
             * Поскольку инициализирующие их выражения относятся к double */
            var s1 = 4.0;
            var s2 = 5.0;

            /*hypot типизирована неявно, и относится к типу double
             * т.к. вывод метода Sqrt(), имеет тип double*/
            var hypot = Math.Sqrt( s1 * s1 + s2 * s2);

            Console.Write("Гипотенуза треугольника со сторонами {0} и {1} равна {2:#.###}\n", s1, s2, hypot);
            Console.ReadKey();

        }
    }
}

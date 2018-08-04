using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace outvar2
{
    class Program
    {
        static void Main(string[] args)
        {
            //examle1
            Console.WriteLine("обычный год {0} дней, високосный год {1} дней", 365, 366); // просто вывод аргументов
            Console.WriteLine();
            
            //examle2
            Console.WriteLine("обычный год {0,5} дней, високосный год {1,9} дней", 365, 366); // вывод агументов с отступами
            Console.WriteLine();

            //example3
            Console.WriteLine("Число\tКвадрат\tКуб"); //Запись в таблицу

                //цикл заполнения таблицы
                for (int i = 1; i < 10; i++)  
                {

                Console.WriteLine("{0}\t{1}\t{2}", i, i * i, i * i * i);

                }
            Console.WriteLine();

            //examlpe4
            double a = 10.0 / 3.0;
            Console.WriteLine("Деление 10 на 3 дает: {0 : #.##} ", a); // вывод значения с округлением, по средствам шаблона
            Console.WriteLine();

            //examle5

            double b = 4567.645 * 3452.687;
            Console.WriteLine("{0:##,###.##}", b); //Разделение вывода по разрядам и округление результата

            //example6
            decimal balance, proficit = 24562.78m, deficit=17633.16m;
            Console.WriteLine("Баланс равен : {0:C1}", balance = proficit - deficit); 
            /*вывод с долларом, чтобы корретно выводило
             *надо на ПК установить по умолчанию единицу "$" 
             *в настройках системы региональных стандартах,
             *дополнительные настройки, денежная единица
             *с рублем работать не хочет хваленый MICROSOFT!*/





            Console.ReadKey();
        }
    }
}

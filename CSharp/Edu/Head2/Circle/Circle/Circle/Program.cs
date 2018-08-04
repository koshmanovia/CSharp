using System;
using System.Threading;


namespace Circle
{
    class Program
    {
        static void Main(string[] args)
        {
           
            //Ввод и определение чисел
            double s;
            Console.WriteLine("Введите радиус: ");
            double r = Convert.ToDouble(Console.ReadLine());

            //авторская смешнявка

            String Text = "Processing";
            String Point = ".";
                for (int i = 0; i < 4; i++)
                {
                    Console.Clear();
                    Text = Text + Point;
                    Console.WriteLine(Text);
                    Thread.Sleep(500);
                }

            //вывод данных на экран   
            Console.Clear();
            s = r * r * 3.1416;
            Console.WriteLine("Прощадь круга равна: " + s);
            Console.ReadKey();


        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoTransform
{
    class Program
    {
        static void Main(string[] args)
        {
            long L = 121343325L;
            double D = L;
            Console.Write("Преобразование long в double \"{0}\" Работает\n", D);

            //L = D; Ни в коем случае не раскомментировать, иначе выйдет кракен
            //так же не работает decimal & double(float), int(all numeric) & char(bool), bool & char
           
            Console.Write("Обратное преобразование long в double не работает ");


                



            Console.ReadKey();
        }      
    }
}

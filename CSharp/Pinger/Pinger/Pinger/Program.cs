using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pinger
{
    class Pinger
    {
        static void Main(string[] args)
        {
            List<String> inputHostName = new List<String>();
            inputHostName.Add("yandex.ru");
            inputHostName.Add("google.com");
            inputHostName.Add("rambler.ru");            
            int  inputHostTimeoute = 10000;
            PingerOutput startingAnalyze = new PingerOutput();
            startingAnalyze.CreateTableHost(inputHostName, inputHostTimeoute);                       
        }
    }
    
    class PingerOutput
    {
        public void CreateTableHost(List<String> addressHost, int timeoutHost)
        {        
            Ping Pinger = new Ping();
            LineTableWrite line = new LineTableWrite();
            List<long> BaseRoadTripTime = new List<long>();
            for (; ; )
            {
                Console.WriteLine("     DNS  Address        IP Address     RoundTrip time ");   
                for (int i = 0; i < addressHost.Count; i++)
                {
                    String tempHostName = addressHost[i];
                    PingReply ReplyInputDataHost = Pinger.Send(tempHostName, timeoutHost);
                    line.run();
                    Console.WriteLine();
                    Console.WriteLine("     {0}       "+"  {1}     "+ "     {2}     ", tempHostName, ReplyInputDataHost.Address.ToString(), ReplyInputDataHost.RoundtripTime);
                }
                line.run();
                Thread.Sleep(3200);
                Console.Clear();
            }
        }        
        
    }
    class LineTableWrite
    {
        public void run()
        {
            for (int j = 0; j < 55; j++)
            {
                Console.Write("_");
            }
        }
    }
}
//чтобы выводило без задержек, стоит попробовать пихать все в массив\класс, и выводить уже готовые значения из массива\класса 
//без работы в реальном времени || реализация тоже идет по потокам??????

//написать метод вычленяющий длинну хоста и если она больше 20 символов то урезать с конца лишнее и забивать таблицу
//переработай имена в более корректные и убодные не будь ленивой задницей, думай как их сделать более удобными постоянно!!!
//добавь ведение лога с привязкой времени 
//сделать потоки, один для вывода на экран сообщений, второй для выхода из цикла(нажатием кнопки, вводом сообщения...??????)
//создание отдельного класса inputHostName, тянуть из файла, плюс отдельная прога для редакирования данных.
//выделение цветом таймаута + обработка исключений если сервер недоступен + грамотное построение таблицы обязательно динамическое
//последним добавить отправку сообщений на эл.почту (продумать как правильно сделать, чтобы не спамить)
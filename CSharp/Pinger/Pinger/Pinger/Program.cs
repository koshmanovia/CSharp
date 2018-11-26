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
            inputHostName.Add("sampo.ru");
            inputHostName.Add("yandex.ru");
            inputHostName.Add("google.com");
            inputHostName.Add("rambler.ru");            
            inputHostName.Add("facebook.com");
            inputHostName.Add("kia.com");
            inputHostName.Add("vk.ru");
            inputHostName.Add("github.com");
            inputHostName.Add("wikipedia.com");
            inputHostName.Add("101.ru");
            inputHostName.Add("harvard.edu");
            inputHostName.Add("nalog.ru");
           // inputHostName.Add(" ");
            int inputHostTimeoute = 10000;
            PingerOutput startingAnalyze = new PingerOutput();
            startingAnalyze.CreateTableHost(inputHostName, inputHostTimeoute);                       
        }
    }
    
    class PingerOutput
    {
        public void CreateTableHost(List<String> addressHost, int timeoutHost)
        {        
            Ping Pinger = new Ping();
            String ipAddress;
            long roadTrip;
            outputDataPinger line = new outputDataPinger();           
            for (; ; )
            {
                Console.WriteLine("     DNS  Address        IP Address     RoundTrip time ");   
                for (int i = 0; i < addressHost.Count; i++)
                {
                    String tempHostName = addressHost[i];
                    PingReply ReplyInputDataHost = Pinger.Send(tempHostName, timeoutHost);
                    line.WriteLine(55);

                    try
                    {
                        ipAddress = ReplyInputDataHost.Address.ToString();
                        roadTrip = ReplyInputDataHost.RoundtripTime;
                    }
                    catch (NullReferenceException)
                    {
                        ipAddress = "Сервер Недоступен";
                        roadTrip = 0;
                    }
                    catch (ArgumentNullException)
                    {
                        tempHostName = "Адрес введен неверно!";
                        ipAddress = "Сервер Недоступен";
                        roadTrip = 0;
                    }
                    
                    Console.WriteLine();
                    line.writeTextColor(tempHostName, ipAddress, roadTrip);                   
                }
                line.WriteLine(55);
                Thread.Sleep(3200);
                Console.Clear();
            }
        }        
        
    }
    class outputDataPinger
    {
        
        public void WriteLine(int inpLongNum)
        {
            for (int j = 0; j < inpLongNum; j++)
            {
                Console.Write("_");
            }
        }
        public void writeTextColor(String tempHostName, String ipAddress, long roadTrip)
        {
            
                if (ipAddress == "Сервер Недоступен")
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                else if (roadTrip < 11)
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                else if (roadTrip < 26)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (roadTrip < 46)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else if (roadTrip < 76)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else if (roadTrip < 106)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (roadTrip < 232)
                    Console.ForegroundColor = ConsoleColor.DarkRed;                    
                else Console.ForegroundColor = ConsoleColor.DarkMagenta;

                Console.WriteLine("     {0}       " + "  {1}     " + "     {2}     ", tempHostName, ipAddress, roadTrip);            
                Console.ResetColor();
        }
            
            //написать метод вычленяющий длинну хоста и если она больше 20 символов то урезать с конца лишнее и забивать таблицу
            //выделение цветом таймаута + обработка исключений если сервер недоступен + грамотное построение таблицы обязательно динамическое
    }

    
}
//чтобы выводило без задержек, стоит попробовать пихать все в массив\класс, и выводить уже готовые значения из массива\класса 
//без работы в реальном времени || реализация тоже идет по потокам??????

//переработай имена в более корректные и убодные не будь ленивой задницей, думай как их сделать более удобными постоянно!!!
//добавь ведение лога с привязкой времени 
//сделать потоки, один для вывода на экран сообщений, второй для выхода из цикла(нажатием кнопки, вводом сообщения...??????)
//создание отдельного класса inputHostName, тянуть из файла, плюс отдельная прога для редакирования данных.
//последним добавить отправку сообщений на эл.почту (продумать как правильно сделать, чтобы не спамить)
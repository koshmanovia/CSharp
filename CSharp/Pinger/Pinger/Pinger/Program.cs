using System;
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
            //переработай имена в более корректные и убодные не будь ленивой задницей!!!!!!!!!!!!!!!!!!!!!!!!!!!
            //добавь ведение лога с привязкой времени 
            //последним добавить отправку сообщений на эл.почту (продумать как правильно сделать, чтобы не спамить)
           
            String inputHostName = "ya.ru";//создание отдельного класса, тянуть из файла или массива данных???????? подумать как сделать лучше
            int  inputHostTimeoute = 10000;
            PingOutput StartingAnalyze = new PingOutput();
            StartingAnalyze.CreateTableHost(inputHostName, inputHostTimeoute);

               

        }
    }
    //переработай имена, они очень плохи! возникает путаница со встроенным классом Ping
    class PingOutput
    {
        public void CreateTableHost(String addressHost, int timeoutHost)
        {
            Ping Pinger = new Ping();
            for (; ; )
                {
                //сделать потоки, один для вывода на экран сообщений, второй для выхода из цикла(нажатием кнопки, вводом сообщения...??????)
                PingReply ReplyInputDataHost = Pinger.Send(addressHost, timeoutHost);
                Console.WriteLine("DNS Address: {0}", addressHost);
                Console.WriteLine("IP Address: {0}", ReplyInputDataHost.Address.ToString());
                Console.WriteLine("RoundTrip time: {0}", ReplyInputDataHost.RoundtripTime);   //выделение цветом таймаута + обработка исключений если сервер недоступен
                Thread.Sleep(1200);
                Console.Clear(); //посмотреть как сделать плавное удаление данных из консоли, чтобы не моргало
                }
        }
    }

}

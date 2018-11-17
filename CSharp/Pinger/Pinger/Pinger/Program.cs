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
            Ping Pinger = new Ping();
            String addressHost = "ya.ru";//создание отдельного класса, тянуть из файла или массива данных???????? подумать как сделать лучше
            int timeoutHost = 10000;

                //в последующем сделать методом, чтобы вызывать для каждого адреса через цикл + добавить вывод не строчками, а таблицей, динамически создаваемой
                for (; ; ) {
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

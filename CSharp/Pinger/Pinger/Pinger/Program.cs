﻿using System;
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
            inputHostName.Add("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijk.com");
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
            String spaceNum1 = "            ";//12
            String spaceNum2 = "           ";//11
           
            for (; ; )
            {
                Console.WriteLine("DNS Address" + spaceNum1 + "IP Address" + spaceNum2 + "Ping");
                for (int i = 0; i < addressHost.Count; i++)
                {
                    String tempHostName = addressHost[i];
                    PingReply ReplyInputDataHost = Pinger.Send(tempHostName, timeoutHost);                  

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
            Thread.Sleep(3200);
            Console.Clear();
            }
        }               
    }
    class outputDataPinger
    {
        
        public void writeCharLine(int inpLongNum, char inpChar)
        {
            for (int j = 0; j < inpLongNum; j++)
            {
                Console.Write(inpChar);
            }
        }
        public void writeTextColor(String hostName, String ipAddress, long roadTrip)
        {
            int LengthHostName = hostName.Length;
            int LengthipAddress = ipAddress.Length;
            String strRoadTrip = roadTrip.ToString();
            int LengthroadTrip = strRoadTrip.Length;

                if (ipAddress == "Сервер Недоступен")
                Console.ForegroundColor = ConsoleColor.Blue;
                else if (roadTrip < 21)
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                else if (roadTrip < 41)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if (roadTrip < 71)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else if (roadTrip < 111)
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                else if (roadTrip < 151)
                    Console.ForegroundColor = ConsoleColor.Red;
                else if (roadTrip < 251)
                    Console.ForegroundColor = ConsoleColor.DarkRed;                    
                else Console.ForegroundColor = ConsoleColor.Magenta;

            if (LengthHostName > 20)
            {
                int tempNumipAddress = 21 - LengthipAddress;
                int tempNumroadTrip = 6 - LengthroadTrip;
                Console.Write(hostName.Substring(0, 19) + "....");
                Console.Write(ipAddress);
                writeCharLine(tempNumipAddress, '.');
                Console.Write(roadTrip);
                writeCharLine(tempNumroadTrip, '.');
                Console.WriteLine();
            }
            else
            {
                int tempNumHostName = 23 - LengthHostName;
                int tempNumipAddress = 21 - LengthipAddress;
                int tempNumroadTrip = 6 - LengthroadTrip;
                Console.Write(hostName);
                writeCharLine(tempNumHostName, '.');
                Console.Write(ipAddress);
                writeCharLine(tempNumipAddress, '.');
                Console.Write(roadTrip);
                writeCharLine(tempNumroadTrip, '.');
                Console.WriteLine();
            }
        Console.ResetColor();          
        }                   
    }    
}
//добавить обработку исключений при отсутвии связи + обработку исключения если пустое значение
//чтобы выводило без задержек, стоит попробовать пихать все в массив\класс, и выводить уже готовые значения из массива\класса 
//без работы в реальном времени || реализация тоже идет по потокам??????

//переработай имена в более корректные и убодные не будь ленивой задницей, думай как их сделать более удобными постоянно!!!
//добавь ведение лога с привязкой времени 
//сделать потоки, один для вывода на экран сообщений, второй для выхода из цикла(нажатием кнопки, вводом сообщения...??????)
//создание отдельного класса inputHostName, тянуть из файла, плюс отдельная прога для редакирования данных.
//последним добавить отправку сообщений на эл.почту (продумать как правильно сделать, чтобы не спамить)
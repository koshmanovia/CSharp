﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Pinger
{
    class Pinger
    {
        static void Main(string[] args)
        {               
            List<String> inputHostName = new List<String>();            
            inputHostName.Add("192.168.1.1");
            inputHostName.Add("sampo.ru");
            inputHostName.Add("gdfshsd.ghgfd ");
            inputHostName.Add("yandex.ru");
            inputHostName.Add("google.com");
            inputHostName.Add(" erty ");
            inputHostName.Add(" ");
            inputHostName.Add("rambler.ru");
            inputHostName.Add("facebook.com");
            inputHostName.Add("100.77.160.1");
            inputHostName.Add("kia.com");
            inputHostName.Add("vk.ru");
            inputHostName.Add("356.457.541.999");
            inputHostName.Add("vk.com");
            inputHostName.Add("github.com");
            inputHostName.Add("wikipedia.com");
            inputHostName.Add("101.ru");
            inputHostName.Add("harvard.edu");
            inputHostName.Add("abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcdefghijk.com");
            inputHostName.Add("10.10.10.10");
            inputHostName.Add("nalog.ru");
    
            int inputHostTimeoute = 1000; //маленький таймаут для тестов! в финале исправь как надо!
            int windowHeightNum = inputHostName.Count() * 2 + 2;
            if (windowHeightNum < 64)
                Console.WindowHeight = windowHeightNum;
            else
            { 
                windowHeightNum = 63;
                Console.WindowHeight = windowHeightNum;
            }
            Console.WindowWidth = 120;
            PingerOutput startingAnalyze = new PingerOutput();
             startingAnalyze.CreateTableHost(inputHostName, inputHostTimeoute);
        }
    }

    class PingerOutput
    {
        public void CreateTableHost(List<String> addressHost, int timeoutHost)
        {
            Ping Pinger = new Ping();
            String ipAddress = null;
            long roadTrip = 0;
            List<String> tempHostName = new List<String>();
            List<String> tempIpAddress = new List<String>();
            List<long> tempRoadTrip = new List<long>();
            String HostName = null;
            outputDataPinger line = new outputDataPinger();

            for (; ; )
            {
               // line.writeHeadTable();
                for (int i = 0; i < addressHost.Count; i++)
                {
                    HostName = addressHost[i];
                    try
                    {
                        PingReply ReplyInputDataHost = Pinger.Send(HostName, timeoutHost);
                        try
                        {
                            ipAddress = ReplyInputDataHost.Address.ToString();
                            roadTrip = ReplyInputDataHost.RoundtripTime;
                            //Console.WriteLine();
                            //line.writeTextColor(HostName, ipAddress, roadTrip);
                            tempHostName.Add(HostName);
                            tempIpAddress.Add(ipAddress);                            
                            tempRoadTrip.Add(roadTrip);

                        }
                        catch (NullReferenceException)
                        {
                            ipAddress = "not available";
                            roadTrip = 0;
                           // Console.WriteLine();
                            //line.writeTextColor(HostName, ipAddress, roadTrip);
                            tempHostName.Add(HostName);
                            tempIpAddress.Add(ipAddress);
                            tempRoadTrip.Add(roadTrip);
                        }
                    }
                    catch (PingException)
                    {                     
                        ipAddress = "HOST NAME ERROR!";
                        roadTrip = 0;
                        //Console.WriteLine();
                        // line.writeTextColor(HostName, ipAddress, roadTrip);
                        tempHostName.Add(HostName);
                        tempIpAddress.Add(ipAddress);
                        tempRoadTrip.Add(roadTrip);
                    }                   
                }
                Console.Clear();
                line.writeHeadTable();
                for (int i = 0; i < addressHost.Count; i++)
                {                   
                    line.writeTextColor(tempHostName[i], tempIpAddress[i], tempRoadTrip[i]);
                    Console.WriteLine();
                }
                Thread.Sleep(3200);
                Console.ForegroundColor = ConsoleColor.Black;
                
            }
            
        }
    }
    class Host
    {
        string hostName { get; set; }
        private byte pingIterator { get; set; }
        private bool hostStatus { get; set; }
        private byte qualityLinkHost { get; set; }
        private short breaksNumHost { get; set; }
        string physLocationHost { get; set; }

        private short BreaksNumHost
        {
            get => breaksNumHost;
            set
            {
                if (breaksNumHost < 1000)
                    breaksNumHost = value;
            }
        }
        public Host(string name, string physLocation)
        {
            hostName = name;
            pingIterator = 0;
            hostStatus = true;
            qualityLinkHost = 100;
            breaksNumHost = 0;
            physLocationHost = physLocation;
        }
    }
    class outputDataPinger // весь вывод текстовых сообщений перенести сюда, и переименовать класс. вывод сделать процедурно, и правильно назвать процедуры, чтобы было понятно
    {

        public void writeCharLine(int inpLongNum, char inpChar)
        {
            for (int j = 0; j < inpLongNum; j++)
            {
                Console.Write(inpChar);
            }
        }
        public void writeCharLine(int inpLongNum)
        {
            char inpChar = ' ';
            for (int j = 0; j < inpLongNum; j++)
            {
                Console.Write(inpChar);
            }
        }
        public void writeHeadTable()
        {
            Console.ForegroundColor = ConsoleColor.Black;  
            Console.BackgroundColor = ConsoleColor.White;            
            writeCharLine(2);
            Console.Write("DNS Address");
            writeCharLine(12);
            Console.Write("IP Address");
            writeCharLine(10);
            Console.Write("Ping");
            writeCharLine(4);
            Console.Write("Quality");
            writeCharLine(3);
           // Console.Write("Breaks");
          //  writeCharLine(3);
            Console.Write("Description");
            writeCharLine(36);
            Console.WriteLine();
        }
        public void writeTextColor(String hostName, String ipAddress, long roadTrip)
        {
            int LengthHostName = hostName.Length;
            int LengthipAddress = ipAddress.Length;
            String strRoadTrip = roadTrip.ToString();
            int LengthroadTrip = strRoadTrip.Length;
            Console.BackgroundColor = ConsoleColor.Black;
            if (ipAddress == "not available")
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }
            else if (ipAddress == "HOST NAME ERROR!")
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else if (roadTrip == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                roadTrip = 1;
            }
            else if (roadTrip < 3)            
                Console.ForegroundColor = ConsoleColor.DarkCyan;                
            else if (roadTrip < 21)
                Console.ForegroundColor = ConsoleColor.Cyan;
            else if (roadTrip < 41)
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            else if (roadTrip < 71)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (roadTrip < 111)
                Console.ForegroundColor = ConsoleColor.Yellow;
            else if (roadTrip < 151)
                Console.ForegroundColor = ConsoleColor.DarkYellow;
            else if (roadTrip < 251)
                Console.ForegroundColor = ConsoleColor.Red;
            else Console.ForegroundColor = ConsoleColor.DarkRed;

            if (LengthHostName > 20)
            {
                int tempNumipAddress = 21 - LengthipAddress;
                int tempNumroadTrip = 6 - LengthroadTrip;
                Console.Write("  " + hostName.Substring(0, 19) + "..  ");
                Console.Write(ipAddress);
                writeCharLine(tempNumipAddress);
                Console.Write(roadTrip);
                writeCharLine(tempNumroadTrip + 2);
                //для расширения просто посмотрть как смотрится в будущем все будет работать
                Console.Write("100%");
                writeCharLine(6);
             //  Console.Write(">999");
             //   writeCharLine(4);
                Console.Write("some description");
                Console.WriteLine();
            }
            else
            {
                int tempNumHostName = 23 - LengthHostName;
                int tempNumipAddress = 21 - LengthipAddress;
                int tempNumroadTrip = 6 - LengthroadTrip;
                Console.Write("  " + hostName);
                writeCharLine(tempNumHostName);
                Console.Write(ipAddress);
                writeCharLine(tempNumipAddress);
                Console.Write(roadTrip);
                writeCharLine(tempNumroadTrip + 2);
                //для расширения просто посмотрть как смотрится  в будущем все будет работать       
                Console.Write("100%");
               writeCharLine(6);
            //    Console.Write(">999");
           //     writeCharLine(4);
                Console.Write("some description");
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
    /*  class Logfile
             {
                 public void writeErr(string catErr )
                 {
                     //продумать условия, при включенном пингере 23.00 - 1.00, чтобы проверял время и если число изменилось, создавал новый файл и писал уже в него
                     //c фиксацией времени и даты с созданием каталогов \месяц_год\число.тхт > в самом документе %время% %имя хоста% %текст ошибки%
                     if (catErr == "Warning")
                     // запись в файл информации о предупреждении высокого пинга 
                     else if (catErr == "not available")
                     // запись в файл информации о недоступности хоста c фиксацией времени и даты
                     else return;
                 }     
             }
        class inputHostNameTMP //после написания класса, удалить TMP <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<    
        {
            public List<Host> InputOtputHostData()
            {

                String projectPath = Environment.CurrentDirectory + "\\Data";
                Console.WriteLine(projectPath);
                if (Directory.Exists(projectPath))
                 //InputHostData() 
                 else
                    // создание файла + заполнение(сделать через процедуру)            

                    return; // тут будет массив объектов Host
            }

            public void InputHostData()//переименуй процедуру
            {
                Console.WriteLine("Наберите команду для продолжения");
                Console.WriteLine("R   - для чтения файла HostDataBase.txt");
                Console.WriteLine("W   - для записи еще данных в конец файла, не стирая данные");
                Console.WriteLine("RW  - для удаления данных из файла и записи их в ручную через консоль");
                Console.WriteLine("          Испольюзуя ключ -b будет сделать backup в %root%\Data\backup\%date%.txt");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "R":
                    case "W":
                    case "RW":
                    case "RW -b":
                    /*      выбор:                 
                     *      1. считать из файла и выйти
                     *      2. дописать данные в файл
                     *      3. стереть данные из файла и записать новые 
                     *      4. стереть данные из файла и записать новые предварительно сделав backup   
                     */
    /*            default:
                    //тут придется использовать goto, то это не точно, т.к пока не сделан выбор надо вернуться в начало
            }
        }        
    }
    class HeadConsolePinger
    {                          

    }*/
}
/* 
 *  динамическое создание объектов! подумать как!
 *
 *   качество связи в % отдельный столбец для каждого столбца. Продумать сброс данных, чтобы не перегружать переменную
 *
 *  займись наконец ООП и раскидай классы по файлам!
 *
 *  чтобы выводило без задержек, стоит попробовать пихать все в массив\класс, и выводить уже готовые значения из массива\класса 
 *  без работы в реальном времени || реализация тоже идет по потокам??????
 *
 *  переработай имена в более корректные и убодные не будь ленивой задницей, думай как их сделать более удобными постоянно!!!
 *
 *  добавь ведение лога с привязкой времени 
 *
 *  сделать потоки, один для вывода на экран сообщений, второй для выхода из цикла(нажатием кнопки, вводом сообщения...??????)
 *
 *  создание отдельного класса inputHostName, тянуть из файла(xml), плюс отдельная прога для редакирования данных.
 *
 *  последним добавить отправку сообщений на эл.почту (продумать как правильно сделать, чтобы не спамить)
 */

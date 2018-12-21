using System;
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
            int inputHostTimeoute = 3000; 
            //горизонтальное выравнивание сделать<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            int windowHeightNum = inputHostName.Count() + 2;
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
            Console.Write(" \n      Идет обработка доступности адресов, пожалуйста подождите...");
            for (; ; )
            {

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
                            tempHostName.Add(HostName);
                            tempIpAddress.Add(ipAddress);                            
                            tempRoadTrip.Add(roadTrip);
                        }
                        catch (NullReferenceException)
                        {
                            ipAddress = "not available";
                            roadTrip = 0;
                            tempHostName.Add(HostName);
                            tempIpAddress.Add(ipAddress);
                            tempRoadTrip.Add(roadTrip);
                        }
                    }
                    catch (PingException)
                    {                     
                        ipAddress = "HOST NAME ERROR!";
                        roadTrip = 0;
                        tempHostName.Add(HostName);
                        tempIpAddress.Add(ipAddress);
                        tempRoadTrip.Add(roadTrip);
                    }                   
                }
                Console.Clear();
                line.writeHeadTable();
                //Console.WriteLine();
                for (int i = 0; i < addressHost.Count; i++)
                {                   
                    line.writeTextColor(tempHostName[i], tempIpAddress[i], tempRoadTrip[i]);
                   // Console.WriteLine();
                    Thread.Sleep(4);
                }
                tempHostName.Clear();
                tempIpAddress.Clear();
                tempRoadTrip.Clear();
                Thread.Sleep(300);
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
            writeCharLine(4);
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
                Console.Write("some description");
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
    /*class Logfile
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
    }*/
    class InputHostNameTMP //после написания класса, удалить TMP <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<    
    {
        List<Host> ListHost = new List<Host>();
        public void InputHostData()//переименуй процедуру
        {
            //вывод данных из файла на экран, пронумерованным списком
            Console.WriteLine("Наберите команду для продолжения");
            Console.WriteLine("R   - для чтения файла \"HostDataBase.txt\"");
            Console.WriteLine("W   - для записи еще данных в конец файла, не стирая данные");
            Console.WriteLine("RW  - для удаления данных из файла и записи их в ручную через консоль");
            Console.WriteLine("      Испольюзуя ключ -b будет сделан backup в \\%root_program_folder%\\Data\\backup\\%date%.txt");
            string command = Console.ReadLine();

            switch (command)
            {
                //добавить редактирование данных по строке
                case "R":
                    break;
                case "W":
                    enterByHand();//ввод данных вручную
                    break;
                case "RW":
                    enterByHand();//ввод данных вручную
                    break;
                case "RW -b":
                    enterByHand();//ввод данных вручную
                    break;
                default:
                    break;//тут придется использовать goto, то это не точно, т.к пока не сделан выбор надо вернуться в начало
            }
        }

        public void enterByHand() //переписать, чтобы не спрашивал каждый раз "да/нет" а только нет для выхода
        {
            String hostName = null;
            String hostDescription = null;
            String reply = null;
            bool checkInp = true;
            while (checkInp == true)
            {             
                    Console.WriteLine("Введите имя хоста");
                    hostName = Console.ReadLine();
                    Console.WriteLine("Введите расположение введенного хоста");
                    hostDescription = Console.ReadLine();
                    createAndFillObjectHost(hostName, hostDescription);
                
                for(;;)
                {
                    Console.WriteLine("Ввести еще один Host? \"да/нет\"");
                    reply = Console.ReadLine();
                    if (reply == "нет")
                    { 
                        checkInp = false;
                        break;
                    }
                    else 
                    if (reply == "да")
                    break;
                    else Console.WriteLine("ОШИБКА: Неверная команда, повторить ввод.");
                }
            }
        }
        public void readFile()
        {
            List<char> poolCharHostDescription = new List<char>;
            List<char> poolCharHostName= new List<char>;
            String tempHostName = "";
            String tempDescription = "";
            List<String> poolLineFromFile = new List<String>();
            String tempLineFromFile = "";
            String projectPath = Environment.CurrentDirectory + "\\Data\\HostDataBase.txt";
            StreamReader fileReader = new StreamReader(projectPath);
            while (tempLineFromFile != null)
            {
                tempLineFromFile = fileReader.ReadLine();
                if (tempLineFromFile != null)
                    poolLineFromFile.Add(tempLineFromFile);
            }
            fileReader.Close();

            for (int i = 0; i < poolLineFromFile.Count; i++)
            {
                tempLineFromFile = poolLineFromFile[i];
                for (int j = 1; i <= tempLineFromFile.Length; i++)
                { 

                }
            }
            //дописать обработку массива lineFromFile - чтобы он из строки вычленял значение хоста и описания и записывал их в экземпляры объекта
        }
        public void createAndFillObjectHost (String HostName, String HostDescription)
        {
            Host newHost = new Host(HostName, HostDescription);
            ListHost.Add(newHost);                   
        }
    }
}
/* 
 *  качество связи в % отдельный столбец для каждой строки. Продумать сброс данных, чтобы не перегружать переменную
 *
 *  займись наконец ООП и раскидай классы по файлам!
 *
 *  переработай имена в более корректные и убодные не будь ленивой задницей, думай как их сделать более удобными постоянно!!!
 *
 *  добавь ведение лога с привязкой времени 
 *
 *  сделать потоки, один для вывода на экран сообщений, второй для выхода из цикла(нажатием кнопки, вводом сообщения...??????)
 *
 *  создание отдельного класса inputHostName, тянуть из файла(xml\txt), плюс отдельная процедура для редакирования данных.
 *
 *  последним добавить отправку сообщений на эл.почту (продумать как правильно сделать, чтобы не спамить)
 */

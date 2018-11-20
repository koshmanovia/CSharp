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
            inputHostName.Add("ya.ru");
            inputHostName.Add("google.com");
            inputHostName.Add("nalog.ru");
            
            int  inputHostTimeoute = 10000;
            PingerOutput startingAnalyze = new PingerOutput();
            for(int i = 0; i < inputHostName.Count; i++)//убрать отсюда этот массив и запихать в метод, прости GitHub что такой позор в тебя заливаю
            {
                String tempHostName = inputHostName[i];
                startingAnalyze.CreateTableHost(tempHostName, inputHostTimeoute);
            }
                       
        }
    }    
    class PingerOutput
    {
        public void CreateTableHost(String addressHost, int timeoutHost)//сюда передавать надо массив и перебирать непосредственно тут
        {
            Ping Pinger = new Ping();
            for ( ; ; )
            {   
                
                PingReply ReplyInputDataHost = Pinger.Send(addressHost, timeoutHost);                               
                Console.WriteLine("|    DNS  Address    |   IP Address   | RoundTrip time|"+ //таблицу переписать, шапка печатается каждый раз, ничего удивительного
                    "\n {0}" + "       {1}"+"    {2}", addressHost, ReplyInputDataHost.Address.ToString(), ReplyInputDataHost.RoundtripTime);              
                Thread.Sleep(1200);
                Console.Clear(); 
            }
        }
        //написать метод вычленяющий длинну хоста и если она больше 20 символов то урезать с конца лишнее и забивать таблицу
    }

}
//переработай имена в более корректные и убодные не будь ленивой задницей, думай как их сделать более удобными постоянно!!!
//добавь ведение лога с привязкой времени 
//сделать потоки, один для вывода на экран сообщений, второй для выхода из цикла(нажатием кнопки, вводом сообщения...??????)
//создание отдельного класса inputHostName, тянуть из файла, плюс отдельная прога для редакирования данных.
//выделение цветом таймаута + обработка исключений если сервер недоступен + грамотное построение таблицы обязательно динамическое
//последним добавить отправку сообщений на эл.почту (продумать как правильно сделать, чтобы не спамить)
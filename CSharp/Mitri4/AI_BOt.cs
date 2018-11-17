using System;
using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Text;

namespace DIK_BOT_Console
{
    class DIK_Bot_AI
    {
        int offset = 0;
        bool firstLaunch = true;
        bool ShutdownCommand = false;
        int updateCount = 0;
        int messagesWithoutAnswer = 0;
        bool botTrigger = false; //обращение к боту

        public void DIK_Bot_AI_Start()
        {
            while (true)
            {
                GetUpdate getUpdate = new GetUpdate();
                getUpdate.offset = offset;

                Request_GetUpdate request_GetUpdate = APIMethods.getUpdates(getUpdate);

               // Console.Write(updateCount + " ");

                foreach (Update update in request_GetUpdate.result)
                {
                    if (update.message != null && update.message.text != null)
                    {
                        Console.WriteLine("Сообщение от " + update.message.from.first_name + " текст сообщения: " + update.message.text);
                        offset = update.update_id + 1;

                        if (firstLaunch || update.message.from.is_bot) continue;

                        bool replyTo = false;
                        string replyText = GetReplyText(update.message.text, ref replyTo);
                        
                        if (replyText != "")
                        {
                            OutMessage outMessage = new OutMessage(update.message.chat.id.ToString(), replyText);
                            if (replyTo) outMessage.reply_to_message_id = update.message.message_id;
                            APIMethods.SendMessage(outMessage);

                            if (ShutdownCommand) Environment.Exit(-1);
                            messagesWithoutAnswer = 0;
                        }
                        else messagesWithoutAnswer++;

                    }

                    updateCount = 0;
                    if (messagesWithoutAnswer > 3) botTrigger = false;
                   

                }

                firstLaunch = false;

                updateCount++;
                if (updateCount == 500)
                {
                    Random rnd = new Random();
                    string[] replyMas = {   "ну и хули молчим тут все?? олло!!",
                                            "посоны че заскучали?"};
                    string mestext = replyMas[rnd.Next(0, replyMas.Length - 1)];
                    mestext = mestext + "\n@Xo66uT @kirkberez @dmd247\nПо такому случаю - шутеечка!\n\n" + Bash();

                    OutMessage outMessage = new OutMessage("-1001103776974", mestext);
                    APIMethods.SendMessage(outMessage);
                }

                if (updateCount == 5) botTrigger = false; 

            }
        }

        string GetReplyText(string messageText, ref bool replyTo)
        {
            string reply = "";
            Random rnd = new Random();            

            string pattern = "@dik_sw_bot|^митрич| митрич";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(messageText) || botTrigger)
            {
                replyTo = true;

                pattern = "время|который час";
                Regex regex2 = new Regex(pattern, RegexOptions.IgnoreCase);
                if (regex2.IsMatch(messageText))
                {
                    reply = "Масковскае время: " + DateTime.Now.ToString("HH:mm");
                    botTrigger = false;
                    return reply;
                }

                pattern = "иди спать";
                regex2 = new Regex(pattern, RegexOptions.IgnoreCase);
                if (regex2.IsMatch(messageText))
                {
                    reply = "Ок. Отключаюсь) Всем пока!";
                    ShutdownCommand = true;
                    return reply;
                }

                //default
                if (!botTrigger)
                {
                    string[] replyMas = { "А", "чо?", "че ти?", "ну чо?", "чо блэт?", "да да?", "слушаю", "я здесь", "чего извольте?", "хльнада?" };                    
                    reply = replyMas[rnd.Next(0, replyMas.Length - 1)];
                    botTrigger = true;
                    return reply;
                }
                
                
            }

            pattern = "^ло{1,}л$";
            regex = new Regex(pattern, RegexOptions.IgnoreCase);

            if (regex.IsMatch(messageText))
            {
                reply = "кек)";
                return reply;
            }

            pattern = "^ке{1,}к[)]{0,}$";
            regex = new Regex(pattern, RegexOptions.IgnoreCase);
            if (regex.IsMatch(messageText))
            {
                reply = "лол)";
                return reply;
            }

            if (rnd.Next(0, 30) == 25)
            {
                reply = "пиздеж!";
                replyTo = true;
                return reply;
            }
            return reply; 
        }

        string Bash()
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://bash.org.ru/forweb/");
            string html = new StreamReader(req.GetResponse().GetResponseStream(), Encoding.Default).ReadToEnd();
            string[] delims = new string[] { "<' + 'div id=\"b_q_t\" style=\"padding: 1em 0;\">", "<' + '/div><' + 'small>" };
            string[] strs = html.Split(delims, StringSplitOptions.None);                            
            string text = strs[1].Replace("<' + 'br>", Environment.NewLine);
            text = text.Replace("<' + 'br />", Environment.NewLine);
            text = text.Replace("&quot;", "\"");
            text = text.Replace("&lt;", "<");
            text = text.Replace("&gt;", ">");
            return text;
        }
    }
}



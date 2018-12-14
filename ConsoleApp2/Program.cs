using BotStop.Core;
using BotStop.Core.CDS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Telegram.Bot;
using System.Threading;
using Telegram.Bot.Args;
using System.Collections.Concurrent;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Net;      
using System.IO;


namespace BotStop
{

    class Program
    {
        static internal ITelegramBotClient botClient;
        static int a;

        static void Main(string[] args)
        {
            botClient = new TelegramBotClient("token");
            var me = botClient.GetMeAsync().Result;
            Console.WriteLine(
              $"Hello, World! I am user {me.Id} and my name is {me.FirstName}."
            );


            //botClient.StartReceiving();
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(int.MaxValue);

        }

        static string LoadPage(string url)
        {
            var result = "";
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var receiveStream = response.GetResponseStream();
                if (receiveStream != null)
                {
                    StreamReader readStream;
                    if (response.CharacterSet == null)
                        readStream = new StreamReader(receiveStream);
                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    result = readStream.ReadToEnd();
                    readStream.Close();
                }
                response.Close();
            }
            return result;
        }


        static IEnumerable<Stops> Cal(string r)
        {
            BotStopEntities1 db = new BotStopEntities1(); //бд
            // список остановок
            List<Stops> stops = new List<Stops>();
            foreach (Stop s in db.Stop)
            {
                stops.Add(new Stops((int)s.Id, s.StopStart.Split(new char[] { ',' }), s.StopEnd, s.SideCount));
            }
            var selectedSide = from stop in stops
                               from name in stop.StopStart
                               where name == r.ToLower()
                               select stop;
            return selectedSide;

        }


        const long TargetChannelId = 784742481;
        static ConcurrentDictionary<int, string[]> Answers = new ConcurrentDictionary<int, string[]>();
        static async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            //бд
            BotStopEntities1 db = new BotStopEntities1(); //бд

            ParserWorker<string> parser; //парсинг
            parser = new ParserWorker<string>(
                     new CdsParser()
                 );
            // список остановок
            List<Stops> stops = new List<Stops>();
            foreach (Stop s in db.Stop)
            {
                stops.Add(new Stops((int)s.Id, s.StopStart.Split(new char[] { ',' }), s.StopEnd, s.SideCount));
            }

            Message message = e.Message;
            int userId = message.From.Id;

            if (message.Type == MessageType.Text)
            {
                if (Answers.TryGetValue(userId, out string[] answers))
                {
                    int count = 0;
                    if (answers[0] == null)
                    {
                        answers[0] = message.Text;
                        await botClient.SendTextMessageAsync(message.Chat, "Выберите остановку:");
                        var selectedSide2 = Cal(e.Message.Text);
                        //выводит стороны, какие есть
                        foreach (Stops stop in selectedSide2)
                        {
                            count++;
                            string s = $"{count}- {stop.StopEnd}";
                            await botClient.SendTextMessageAsync(
                               text: s,
                             chatId: e.Message.Chat

                           );
                        }
                    }
                    else if (answers[1] == null)
                    {
                        answers[1] = message.Text;
                        Answers.TryRemove(userId, out string[] _);
                        if (answers[1] == "1" || answers[1] == "2" || answers[1] == "3" || answers[1] == "4")
                        {
                            int caseSwitch = Convert.ToInt32(answers[1]);
                            switch (caseSwitch)
                            {
                                case 1:
                                    var selectedSide = Cal(answers[0]);
                                    var selectedStops = from stop in selectedSide
                                                        where stop.SideCount == 1
                                                        select stop;
                                    foreach (Stops stop in selectedStops)
                                    {
                                        parser.Settings = new CdsSettings((int)stop.Id);
                                        parser.Cool();
                                    }
                                    break;
                                case 2:
                                    var selectedSide3 = Cal(answers[0]);
                                    Console.WriteLine(e.Message.Text);
                                    IEnumerable<Stops> selectedStops2 = from stop in selectedSide3
                                                                        where stop.SideCount == /*Convert.ToInt32(e.Message.Text)*/ 2
                                                                        select stop;
                                    foreach (Stops stop in selectedStops2)
                                    {
                                        parser.Settings = new CdsSettings((int)stop.Id);
                                        Console.WriteLine(stop.Id);
                                        parser.Cool2();
                                    }
                                    break;
                                case 3:
                                    var selectedSide4 = Cal(answers[0]);
                                    Console.WriteLine("Case 3");
                                    Console.WriteLine(e.Message.Text);
                                    selectedStops = from stop in selectedSide4
                                                    where stop.SideCount == Convert.ToInt32(e.Message.Text)
                                                    select stop;
                                    foreach (Stops stop in selectedStops)
                                    {
                                        parser.Settings = new CdsSettings((int)stop.Id);
                                        Console.WriteLine(stop.Id);
                                        parser.Cool3();
                                    }
                                    break;
                            }
                        }


                    }
                }
                else
                {
                    Answers.TryAdd(userId, new string[2]);
                    await botClient.SendTextMessageAsync(message.Chat, "Введите название остановки!");
                }
          }
        }      
      }
    }




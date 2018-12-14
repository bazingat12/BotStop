using AngleSharp.Parser.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using System.Threading;
using Telegram.Bot.Args;
using BotStop.Core.CDS;
using Telegram.Bot.Types;

namespace BotStop.Core
{
    internal static class xXXx
    {
        internal static string xXx;
        internal static string xXx2;
    }
  internal  class ParserWorker<T> where T : class
    {
        internal static string xXx3;
        static ITelegramBotClient botClient;
        IParser<T> parser;
        IParserSettings parserSettings;
        private static string z = string.Empty;
        static string l;
        static string n;

        HtmlLoader loader;

        bool isActive;

        #region Properties

        public IParser<T> Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }

        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }

        public bool IsActive
        {
            get
            {
                return isActive;
            }
        }

        #endregion

        public event Action<object, T> OnNewData;
        public event Action<object> OnCompleted;

       public void Cool()
        {
            isActive = true;
            botClient = new TelegramBotClient("token");
            botClient.OnMessage += Bot_OnMessage;
            botClient.StartReceiving();
            Thread.Sleep(5000);
            return;
        }

        public void Cool2()
        {
            isActive = true;
            botClient = new TelegramBotClient("token");
            botClient.StartReceiving();
            botClient.OnMessage += Bot_OnMessage2;
            Thread.Sleep(5000);
            return;
        }

        public void Cool3()
        {
            isActive = true;
            botClient = new TelegramBotClient("token");
            botClient.StartReceiving();
            botClient.OnMessage += Bot_OnMessage3;
            Thread.Sleep(5000);
            return;
        }

        public async void Bot_OnMessage3(object sender, MessageEventArgs e)
        {
            if (e.Message.Text == "3")
            {
                 isActive = true;
                T x = await Worker();
                xXXx.xXx = Convert.ToString(x);
                string t3 = Convert.ToString(x);
                Console.WriteLine(xXXx.xXx);
                await botClient.SendTextMessageAsync(
                   text: t3,
                 chatId: e.Message.Chat
               );
                return;
            }
            else { return; }
        }

        public async void Bot_OnMessage2(object sender, MessageEventArgs e)
        {
            if (e.Message.Text == "2")
            {
                Console.WriteLine("ТЕКСТ ИЗ МЕТОДА " + e.Message.Text);
                // isActive = true;
                T x = await Worker();
                string t = Convert.ToString(x);
                Console.WriteLine(t);
                await /*Program.*/botClient.SendTextMessageAsync(
                   text: /*xXXx.xXx*/ t,
                 chatId: e.Message.Chat
               );
                return;
            }
            else { return; }
        }

            public async void Bot_OnMessage(object sender, MessageEventArgs e)
        {
            if (e.Message.Text == "1")
            {
                isActive = true;
                T x = await Worker();
                string t2 = Convert.ToString(x);
                await /*Program.*/botClient.SendTextMessageAsync(
                   text: t2,
                 chatId: e.Message.Chat
               );
                return;
            }
            else { return; }
        }

            public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
        }

        public async void StartAsync()
        {
            isActive = true;
        }

        public void Abort()
        {
            isActive = false;
        }

        public async Task<T> Worker()
        {
            int i = parserSettings.StartPoint;
                var source = await loader.GetSourceByPageId(i);
                var domParser = new HtmlParser();
                var document = await domParser.ParseAsync(source);
                var result = parser.Parse(document);
            z = Convert.ToString(result);
            return result;
        }
    }
}


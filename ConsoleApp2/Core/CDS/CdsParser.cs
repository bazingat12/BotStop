using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;
using ConsoleTables;
using Telegram.Bot;
using System.Threading;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace BotStop.Core.CDS
{
    class CdsParser : IParser<string>
    {
        static ITelegramBotClient botClient;
        static string l;
        static string pars;
        static List<string> list = new List<string>();
        static string cc = null;

        public string Parse(IHtmlDocument document)
        {
            cc = null;
            var items = document.QuerySelectorAll("td");
            int count = 1;
            foreach (var item in items)
            {
                if (count % 10 == 1 || count % 10 == 6)
                {
                    pars = item.TextContent;
                    cc = cc + pars;
                    // Console.Write(/*item.TextContent*/pars, "\t");
                }

                if (count % 10 == 2 || count % 10 == 7)
                {
                    pars = item.TextContent;
                    cc = cc + pars + "\n";
                    //Console.WriteLine(/*item.TextContent*/pars, "\t");
                }
                count++;
            }
            //Console.Write("Во че получилось: " + cc, "\t");
            return CdsParser.cc;
        }

            }

        }

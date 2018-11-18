using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngleSharp.Dom.Html;
using ConsoleTables;

namespace BotStop.Core.CDS
{
    class CdsParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();

             var items = document.QuerySelectorAll("td");
            int count = 1;
            foreach (var item in items)
            {
                if (count % 10 == 1 || count % 10 == 6 )
                {
                    Console.Write(item.TextContent, "\t");
                }

                if (count % 10 == 2 || count % 10 == 7)
                {
                    Console.WriteLine(item.TextContent, "\t");
                }
                 count++;
            }
            return list.ToArray();
        }
    }
}
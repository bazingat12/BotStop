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

             var items = document.QuerySelectorAll("tr");

            foreach (var item in items)
            {
                 Console.WriteLine(item.TextContent);           
            }
            return list.ToArray();
        }
    }
}
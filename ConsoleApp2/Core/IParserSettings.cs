using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotStop.Core //настройка парсинга страницы
{
    interface IParserSettings
    {
        string BaseUrl { get; set; }//url адрес сайта

        string Prefix { get; set; }//

        int StartPoint { get; set; }//с какой страницы парсим данные

    }
}
using BotStop.Core;
using BotStop.Core.CDS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BotStop
{
     class Program
    {
        static void Main(string[] args)
        {
            ParserWorker<string[]> parser;
            parser = new ParserWorker<string[]>(
                     new CdsParser()
                 );

            List<Stop> stops = new List<Stop>
{
    new Stop {BusStop=181, Side= "ул. космонавтра Владислава Волкова", SideCount = 1, Name = new List<string> {"Ипподром", "ипподром" , "иподром", "Иподром"}},
    new Stop {BusStop=121, Side= "Слобода Егоровская", SideCount = 2, Name = new List<string> {"Ипподром", "ипподром" , "иподром", "Иподром"}},
    new Stop {BusStop=102, Side= "Европейские улочки", SideCount = 3, Name = new List<string> {"Ипподром", "ипподром" , "иподром", "Иподром"}},
    new Stop {BusStop=294, Side= "ул. Ивана Попова", SideCount = 1, Name = new List<string> {"Первая больница", "первая больница" , "первая", "больница"}},
    new Stop {BusStop=295, Side= "ул. Красина", SideCount = 2, Name = new List<string> {"Первая больница", "первая больница" , "первая", "больница"}},
    new Stop {BusStop=55, Side= "ул. Украинская", SideCount = 1, Name = new List<string> {"Четвертой пятилетки", "четвертой пятилетки" , "4 пятилетки", "Пятилетки", "пятилетки"}},
    new Stop {BusStop=61, Side= "Слобода Столбики", SideCount = 2, Name = new List<string> {"Четвертой пятилетки", "четвертой пятилетки" , "4 пятилетки", "Пятилетки", "пятилетки"}},
    new Stop {BusStop=248, Side= "ул. Гайдара", SideCount = 1, Name = new List<string> {"Шестая больница", "шестая больница", "6 больница"}},
    new Stop {BusStop=258, Side= "Фабрика обуви 'Темп'", SideCount = 1, Name = new List<string> {"Авторынок", "авторынок"}},
    new Stop {BusStop=269, Side= "ул. Луганская", SideCount = 2, Name = new List<string> {"Авторынок", "авторынок"}},
    new Stop {BusStop=609, Side= "Малахит", SideCount = 1, Name = new List<string> {"Автосалон", "автосалон"}},
    new Stop {BusStop=909, Side= "ул. Романа Ердякова", SideCount = 2, Name = new List<string> {"Автосалон", "автосалон"}},
    new Stop {BusStop=120, Side= "Филармония", SideCount = 1, Name = new List<string> {"Администрация города", "администрация города","Администрация", "администрация"}},
    new Stop {BusStop=401, Side= "ул. Пролетарская", SideCount = 2, Name = new List<string> {"Администрация города", "администрация города","Администрация", "администрация"}},
    new Stop {BusStop=404, Side= "Кинотеатр 'Октябрь'", SideCount = 3, Name = new List<string> {"Администрация города", "администрация города","Администрация", "администрация"}},
    new Stop {BusStop=281, Side= "Магазин 'Детский мир'", SideCount = 1, Name = new List<string> {"Азина", "азина"}},
    new Stop {BusStop=289, Side= "ул. Володарского", SideCount = 2, Name = new List<string> {"Азина", "азина"}},
    new Stop {BusStop=15, Side= "Конечная", SideCount = 1, Name = new List<string> {"Андрея Упита", "андрея упита", "Упита", "упита"}},
    new Stop {BusStop=165, Side= "Красная горка", SideCount = 2, Name = new List<string> {"Андрея Упита", "андрея упита", "Упита", "упита"}},
    new Stop {BusStop=804, Side= "Школа №42", SideCount = 3, Name = new List<string> {"Андрея Упита", "андрея упита", "Упита", "упита"}},
    new Stop {BusStop=908, Side= "Автосалон", SideCount = 1, Name = new List<string> {"Армянская церковь", "армянская церковь", "армянская", "церковь", "Армянская", "Церковь"}},
    new Stop {BusStop=56, Side= "ул. Металлистов", SideCount = 1, Name = new List<string> {"база", "База", "Кировснаб", "кировснаб", "База Кировснаб", "база Кировснаб", "база кировснаб"}},





            };


            Console.WriteLine("Введите остановку");
            string nameBus = Convert.ToString(Console.ReadLine());
            var selectedSide = from stop in stops
                                from name in stop.Name
                                where name == nameBus
                                select stop;
            int count = 0;
            Console.WriteLine("В сторону(выберите цифру):");
            foreach (Stop stop in selectedSide)
            {
                count++;
                Console.WriteLine($"{count}- {stop.Side}");
            }
            int usertext = Convert.ToInt32(Console.ReadLine());
            count = usertext;
            var selectedStops = from stop3 in stops
                                from name in stop3.Name
                                where name == nameBus
                                where stop3.SideCount == count
                                 select stop3;
            foreach (Stop stop3 in selectedStops)
            {
                string stops2 = stop3.BusStop.ToString();
                int stops3 = Convert.ToInt32(stops2);
                parser.Settings = new CdsSettings((int)stops3);
                parser.Start();
                parser.OnNewData += Parser_OnNewData;
            }
            Console.ReadLine();
        }

        private static void Parser_OnNewData(object arg1, string[] arg2)
        {
            foreach (string item in arg2)
            Console.Write(item + " ");
            Console.ReadLine();
        }
    }
}


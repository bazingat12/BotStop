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
};


            Console.WriteLine("Введите остановку");
            string nameBus = Convert.ToString(Console.ReadLine());
            var selectedStops = from stop in stops
                                from name in stop.Name
                                where name == nameBus
                                select stop;
            int count = 0;
            Console.WriteLine("Введите цифру остановки, в какую сторону вам надо:");
            foreach (Stop stop in selectedStops)
            {
                count++;
                Console.WriteLine($"{count}- {stop.Side}");
            }
            int usertext = Convert.ToInt32(Console.ReadLine());
            count = usertext;
            var selectedStops3 = from stop3 in stops
                                 where stop3.SideCount == count
                                 select stop3;
            foreach (Stop stop3 in selectedStops3)
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


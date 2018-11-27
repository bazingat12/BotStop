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
            BotStopEntities1 db = new BotStopEntities1();

            ParserWorker<string[]> parser;
            parser = new ParserWorker<string[]>(
                     new CdsParser()
                 );

            List<Stops> stops = new List<Stops>();
            foreach (Stop s in db.Stop)
            {
                stops.Add(new Stops((int)s.Id, s.StopStart.Split(new char[] { ',' }), s.StopEnd, s.SideCount));
            }

            Console.WriteLine("Введите остановку");
            string nameBus = Convert.ToString(Console.ReadLine());
            var selectedSide = from stop in stops
                               from name in stop.StopStart
                               where name == nameBus.ToLower()
                               select stop;
            int count = 0;
            Console.WriteLine("В сторону(выберите цифру):");
            foreach (Stops stop in selectedSide)
            {
                count++;
                Console.WriteLine($"{count}- {stop.StopEnd}");
            }

            count = Convert.ToInt32(Console.ReadLine());
            var selectedStops = from stop in selectedSide
                                where stop.SideCount == count
                                select stop;
            foreach (Stops stop in selectedStops)
            {
                parser.Settings = new CdsSettings((int)stop.Id);
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


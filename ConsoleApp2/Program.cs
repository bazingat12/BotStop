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
            Console.WriteLine("Введите остановку");
            int a = Convert.ToInt32(Console.ReadLine());
            parser.Settings = new CdsSettings((int)a);
            parser.Start();
            parser.OnNewData += Parser_OnNewData;
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


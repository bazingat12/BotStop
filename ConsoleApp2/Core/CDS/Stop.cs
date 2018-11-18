using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotStop.Core.CDS
{
    class Stop
    {
        public int BusStop { get; set; }
        public string Side { get; set; }
        public int SideCount { get; set; }
        public List<string> Name { get; set; }
        public Stop()
        {
            Name = new List<string>();
        }
    }
}

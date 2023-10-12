using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01.Models
{
    class Report
    {
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public Location Loc { get; set; }
        public int CountAnumals { get; set; }
        public int Close { get; set; }
        public int Sum { get; set; }

        public Report(DateTime dateStart, DateTime dateFinish, Location loc, int close, int countAnumals, int sum)
        {
            DateStart = dateStart;
            DateFinish = dateFinish;
            Loc = loc;
            Close = close;
            CountAnumals = countAnumals;
            Sum = sum;
        }
    }
}

using GrpcClient_PI_21_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01
{
    public class Act
    {
        public int ActNumber { get; set; }
        public int CountDogs { get; set; }
        public int CountCats { get; set; }
        public int Sum { get; set; }
        public Organization Organization { get; set; }
        public DateTime Date { get; set; }
        public string TargetCapture { get; set; }
        public Contract Contracts { get; set; }

        public Act(int actNumber, int countDogs, int countCats, Organization organization, DateTime date, string targetCapture, Contract contracts)
        {
            ActNumber = actNumber;
            CountDogs = countDogs;
            CountCats = countCats;
            Sum = countDogs + countCats;
            Organization = organization;
            Date = date;
            TargetCapture = targetCapture;
            Contracts = contracts;
        }

        public static Act Empty = new(-1, 0, 0,
                        new Organization(-1, "", "", "", "", "", ""),
                        DateTime.MinValue, "",
                        new Contract(-1, DateTime.MinValue, DateTime.MinValue,
                        new Organization(-1, "", "", "", "", "", ""),
                        new Organization(-1, "", "", "", "", "", "")));
    }
}

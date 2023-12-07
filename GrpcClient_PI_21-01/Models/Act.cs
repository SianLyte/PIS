using GrpcClient_PI_21_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01
{
    [FilterableModel]
    public class Act
    {
        public int ActNumber { get; set; }
        [Filterable("dog_count")]
        public int CountDogs { get; set; }
        [Filterable("cat_count")]
        public int CountCats { get; set; }
        [Filterable("dog_count+cat_count")]
        public int Sum { get; private set; }
        [Filterable("organization_id")]
        public Organization Organization { get; set; }
        [Filterable("created_at")]
        public DateTime Date { get; set; }
        [Filterable("goal")]
        public string TargetCapture { get; set; }
        [Filterable("municipal_contract_id")]
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
                        new Organization(-1, "", "", "", new Location(-1, ""), 0, ""),
                        DateTime.MinValue, "",
                        new Contract(-1, DateTime.MinValue, DateTime.MinValue,
                        new Organization(-1, "", "", "", new Location(-1, ""), 0, ""),
                        new Organization(-1, "", "", "", new Location(-1, ""), 0, "")));
    }
}

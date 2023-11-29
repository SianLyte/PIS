using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01.Models
{
    public class App
    {
        public DateTime date { get; set; }
        public int number { get; set; }
        public Models.Location locality { get; set; }
        public string territory { get; set; }
        public string animalHabiat { get; set; }
        public string urgencyOfExecution { get; set; }
        public string animaldescription { get; set; }
        public string applicantCategory { get; set; }
        public App(DateTime date, int number, Location locality, string territory, string animalHabiat, string urgencyOfExecution, string animaldescription, string applicantCategory)
        {
            this.date = date;
            this.number = number;
            this.locality = locality;
            this.territory = territory;
            this.animalHabiat = animalHabiat;
            this.urgencyOfExecution = urgencyOfExecution;
            this.animaldescription = animaldescription;
            this.applicantCategory = applicantCategory;
        }
    }
}

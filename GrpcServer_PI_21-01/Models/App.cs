using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Models
{
    [FilterableModel("catch_request")]
    public class App
    {
        [Filterable("id")]
        public int number { get; set; }

        [Filterable("created_at")]
        public DateTime date { get; set; }

        [Filterable("cityid")]
        public Location locality { get; set; }

        [Filterable("territory")]
        public string territory { get; set; }

        [Filterable("habitat")]
        public string animalHabiat { get; set; }

        [Filterable("urgency")]
        public string urgencyOfExecution { get; set; }

        [Filterable("descr")]
        public string animaldescription { get; set; }

        [Filterable("client_category")]
        public string applicantCategory { get; set; }
        
        [Filterable("status")]
        public AppStatus status { get; set; }

        public App(DateTime date, int number, Location locality, string territory, string animalHabiat, string urgencyOfExecution, string animaldescription, string applicantCategory, AppStatus status)
        {
            this.date = date;
            this.number = number;
            this.locality = locality;
            this.territory = territory;
            this.animalHabiat = animalHabiat;
            this.urgencyOfExecution = urgencyOfExecution;
            this.animaldescription = animaldescription;
            this.applicantCategory = applicantCategory;
            this.status = status;
        }
        public override bool Equals(object? obj)
        {
            App obj1 = obj as App;
            return this.number == obj1.number;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}

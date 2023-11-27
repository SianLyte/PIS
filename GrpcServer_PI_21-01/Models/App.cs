using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Models
{
    public class App
    {
        public DateTime date { get; set; }
        public int number { get; set; }
        public string locality { get; set; }
        public string territory { get; set; }
        public string animalHabiat { get; set; }
        public string urgencyOfExecution { get; set; }
        public string animaldescription { get; set; }
        public string applicantCategory { get; set; }
        public App(DateTime date, int number, string locality, string territory, string animalHabiat, string urgencyOfExecution, string animaldescription, string applicantCategory)
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
        public override bool Equals(object? obj)
        {
            App obj1 = obj as App;
            return this.number == obj1.number;
        }

        public static App GetById(int id, NpgsqlConnection cn)
        {
            NpgsqlCommand cmd = new($"SELECT * FROM catch_request WHERE id = {id}");
            cmd.Connection = cn;
            cn.Open();
            var reader = cmd.ExecuteReader();
            string[] arr = { "0", "0", "0", "0", "0", "0", "0" };
            while (reader.Read())
            {
                arr[0] = (reader[1].ToString());
                arr[1] = reader[7].ToString();
                arr[2] = reader[2].ToString();
                arr[3] = reader[3].ToString();
                arr[4] = reader[4].ToString();
                arr[5] = reader[5].ToString();
                arr[6] = reader[6].ToString();
            }
            reader.Close();
            cn.Close();
            return new App(DateTime.Parse(arr[0]), id, arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
        }
    }
}

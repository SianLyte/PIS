using GrpcServer_PI_21_01.Data;
using GrpcServer_PI_21_01.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Models
{
    [FilterableModel("act_catch_request")]
    public class ActApp
    {
        public int ActAppNumber { get; set; }
        [Filterable("act_id")]
        public Act Act{ get; set; }
        [Filterable("catch_request_id")]
        public App Application { get; set; }

        [Filterable("count_dogs")]
        public int CountDogs { get; set; }


        [Filterable("count_cats")]
        public int CountCats { get; set; }


        public ActApp(int actAppNumber, Act act, App application, int countDogs, int countCats)
        {
            ActAppNumber = actAppNumber;
            Act = act;
            Application = application;
            CountDogs = countDogs;
            CountCats = countCats;

        }

        public static ActApp GetByActId(int actId, NpgsqlConnection cn)
        {
            NpgsqlCommand cmd = new($"SELECT * FROM act_catch_request WHERE act_id = {actId}");
            cmd.Connection = cn;
            cn.Open();
            var reader = cmd.ExecuteReader();
            string[] arr = { "0", "0", "0" };
            while (reader.Read())
            {
                arr[0] = reader[0].ToString(); //id 
                arr[1] = reader[1].ToString(); //act_id
                arr[2] = reader[2].ToString(); //app_id
                arr[3] = reader[3].ToString(); //count_dogs
                arr[4] = reader[4].ToString(); //count_cats
            }
            reader.Close();
            cn.Close();
            return new ActApp(int.Parse(arr[0]), ActRepository.GetAct(int.Parse(arr[1])), AppRepository.GetApplication(int.Parse(arr[2])), int.Parse(arr[3]), int.Parse(arr[4]));
        }

    }
}

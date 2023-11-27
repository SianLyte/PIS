using GrpcServer_PI_21_01.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01
{
    public class ActApp
    {
        public int ActAppNumber { get; set; }
        public Act Act{ get; set; }
        public App Application { get; set; }

        public ActApp(int actAppNumber, Act act, App application)
        {
            ActAppNumber = actAppNumber;
            Act = act;
            Application = application;
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
            }
            reader.Close();
            cn.Close();
            return new ActApp(int.Parse(arr[0]), Act.GetById(int.Parse(arr[1]), cn), App.GetById(int.Parse(arr[2]), cn));
        }

    }
}

using GrpcServer_PI_21_01.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01
{
    public class Act
    {
        public int ActNumber { get; set; }
        public int CountDogs { get; set; }
        public int CountCats { get; set; }
        public int Sum { get; private set; }
        public Organization Organization { get; set; }
        public DateTime Date { get; set; }
        public string TargetCapture { get; set; }
        public App Application { get; set; }
        public Contract Contracts { get; set; }

        public Act(int actNumber, int countDogs, int countCats, Organization organization, DateTime date, string targetCapture, App application, Contract contracts)
        {
            ActNumber = actNumber;
            CountDogs = countDogs;
            CountCats = countCats;
            Sum = countDogs + countCats;
            Organization = organization;
            Date = date;
            TargetCapture = targetCapture;
            Application = application;
            Contracts = contracts;
        }

        public static Act GetById(int id, NpgsqlConnection cn)
        {
            NpgsqlCommand cmd = new($"SELECT * FROM act WHERE id = {id}");
            cmd.Connection = cn;
            var reader = cmd.ExecuteReader();
            string[] arr = { "0", "0", "0", "0", "0", "0", "0" };
            while (reader.Read())
            {
                arr[0] = reader[1].ToString();
                arr[1] = reader[2].ToString();
                arr[2] = reader[3].ToString(); //"org"
                arr[3] = reader[4].ToString(); //"date"
                arr[4] = reader[5].ToString();
                arr[5] = reader[6].ToString(); //app
                arr[6] = reader[7].ToString(); //contract
            }
            reader.Close();
            return new Act(id, int.Parse(arr[0]), int.Parse(arr[1]), Organization.GetById(int.Parse(arr[2]), cn),
                DateTime.Parse(arr[3]), arr[4], App.GetById(int.Parse(arr[5]), cn), Contract.GetById(int.Parse(arr[6]), cn));
        }

    }
}

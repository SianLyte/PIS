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
        //public App Application { get; set; }
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
            //Application = application;
            Contracts = contracts;
        }

        public override bool Equals(object? obj)
        {
            Act obj1 = obj as Act;
            return this.ActNumber == obj1.ActNumber;
        }

        public static Act GetById(int id, NpgsqlConnection cn, bool connectionAlreadyOpen = false)
        {
            NpgsqlCommand cmd = new($"SELECT * FROM act WHERE id = {id}");
            cmd.Connection = cn;
            if (!connectionAlreadyOpen)
                cn.Open();

            var reader = cmd.ExecuteReader();
            if (!reader.Read()) throw new Exception("Unknown ID for act: " + id);

            var dogCount = reader.GetInt32(reader.GetOrdinal("dog_count"));
            var catCount = reader.GetInt32(reader.GetOrdinal("cat_count"));
            var orgId = reader.GetInt32(reader.GetOrdinal("organization_id"));
            var createdAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
            var goal = reader.GetString(reader.GetOrdinal("goal"));
            var contrId = reader.GetInt32(reader.GetOrdinal("municipal_contract_id"));

            reader.Close();
            if (!connectionAlreadyOpen)
                cn.Close();

            return new Act(id, dogCount, catCount,
                Organization.GetById(orgId, cn, connectionAlreadyOpen),
                createdAt, goal,
                Contract.GetById(contrId, cn, connectionAlreadyOpen));
        }

    }
}

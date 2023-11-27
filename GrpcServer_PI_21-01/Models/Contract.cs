using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Models
{
    public class Contract
    {
        public int IdContract { get; set; }
        public DateTime DateConclusion { get; set; }
        public DateTime ActionDate { get; set; }
        public Organization Executer { get; set; }
        public Organization Costumer { get; set; }

        public Contract(int idContract, 
            DateTime dateConclusion, DateTime actionDate, 
            Organization executer, Organization costumer)
        {
            IdContract = idContract;
            DateConclusion = dateConclusion;
            ActionDate = actionDate;
            Executer = executer;
            Costumer = costumer;
        }

        public static Contract GetById(int id, NpgsqlConnection cn, bool connectionAlreadyOpen = false)
        {
            NpgsqlCommand cmd = new($"SELECT * FROM municipal_contract WHERE id = {id}");
            cmd.Connection = cn;
            if (!connectionAlreadyOpen)
                cn.Open();

            var reader = cmd.ExecuteReader();
            if (!reader.Read()) throw new Exception("Unknown ID for Contract: " + id);

            var createdAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
            var overAt = reader.GetDateTime(reader.GetOrdinal("validity_date"));
            var performerId = reader.GetInt32(reader.GetOrdinal("performer_id"));
            var customerId = reader.GetInt32(reader.GetOrdinal("customer_id"));

            reader.Close();
            if (!connectionAlreadyOpen)
                cn.Close();

            return new Contract(id, createdAt, overAt,
                Organization.GetById(performerId, cn, connectionAlreadyOpen),
                Organization.GetById(customerId, cn, connectionAlreadyOpen));
        }

    }
}

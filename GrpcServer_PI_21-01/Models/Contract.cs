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

        public static Contract GetById(int id, NpgsqlConnection cn)
        {
            NpgsqlCommand cmd = new($"SELECT * FROM municipal_contract WHERE id = {id}");
            cmd.Connection = cn;
            cn.Open();
            var reader = cmd.ExecuteReader();
            string[] arr = { "0", "0", "0", "0", "0" };

            while (reader.Read())
            {
                arr[0] = (reader[0].ToString()); //id
                arr[1] = (reader[1].ToString()); //data
                arr[2] = ((reader[2].ToString())); //data
                arr[3] = (reader[3].ToString()); //org
                arr[4] = (reader[4].ToString()); //org
            }
            reader.Close();
            cn.Close();
            //Models.Location location = Location.GetById(int.Parse(arr[2]), cn);
            Organization executer = Organization.GetById(int.Parse(arr[3]), cn);
            Organization costumer = Organization.GetById(int.Parse(arr[4]), cn);

            return new Contract(id, DateTime.Parse(arr[1]), DateTime.Parse(arr[2]), executer, costumer);
        }

    }
}

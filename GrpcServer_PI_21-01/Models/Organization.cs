using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Models
{
    public class Organization
    {
        public int idOrg { get; set; }
        public string name { get; set; }
        public string INN { get; set; }
        public string KPP { get; set; }
        public string registrationAdress { get; set; }
        public string type { get; set; }
        public string status { get; set; }

        public Organization(int IdOrg, string name, string iNN, string kPP, string registrationAdress, string type, string status)
        {
            this.idOrg = IdOrg;
            this.name = name;
            INN = iNN;
            KPP = kPP;
            this.registrationAdress = registrationAdress;
            this.type = type;
            this.status = status;
        }

        public static Organization GetById(int id, NpgsqlConnection cn)
        {

            NpgsqlCommand cmd = new($"SELECT * FROM organization WHERE id = {id}") { Connection = cn };
            string[] arr = { "0", "0", "0", "0", "0", "0", "0" };

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                arr[0] = reader[1].ToString();
                arr[1] = reader[2].ToString();
                arr[2] = reader[3].ToString();
                arr[3] = reader[4].ToString();
                arr[4] = reader[5].ToString();
                arr[5] = reader[6].ToString();
            }
            reader.Close();
            return new Organization(id, arr[0], arr[1], arr[2], arr[3], arr[4], arr[5]);
        }
    }
}

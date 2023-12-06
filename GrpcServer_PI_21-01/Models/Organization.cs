using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Models
{
    [FilterableModel("organization")]
    public class Organization
    {
        public int idOrg { get; set; }

        [Filterable("namee")]
        public string name { get; set; }

        [Filterable("inn")]
        public string INN { get; set; }

        [Filterable("kpp")]
        public string KPP { get; set; }

        [Filterable("registration")]
        public string registrationAdress { get; set; }

        [Filterable("typee")]
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

        public static Organization GetById(int id, NpgsqlConnection cn, bool connectionAlreadyOpen = false)
        {

            NpgsqlCommand cmd = new($"SELECT * FROM organization WHERE id = {id}") { Connection = cn };
            string[] arr = { "0", "0", "0", "0", "0", "0", "0" };
            if (!connectionAlreadyOpen)
                cn.Open();

            var reader = cmd.ExecuteReader();
            if (!reader.Read()) throw new Exception("Unknown ID for organization: " + id);

            var name = reader.GetString(reader.GetOrdinal("namee"));
            var inn = reader.GetString(reader.GetOrdinal("inn"));
            var kpp = reader.GetString(reader.GetOrdinal("kpp"));
            var registrationAdress = reader.GetString(reader.GetOrdinal("registration"));
            var type = reader.GetString(reader.GetOrdinal("typee"));
            var status = reader.GetString(reader.GetOrdinal("status"));

            reader.Close();
            if (!connectionAlreadyOpen)
                cn.Close();

            return new Organization(id, name, inn, kpp, registrationAdress, type, status);
        }
    }
}

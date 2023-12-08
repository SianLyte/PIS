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

        public static OrganizationType StringToEnum(string type)
        {
            if (type == "DirectoryValues")
                return OrganizationType.DirectoryValues;
            if (type == "GovernmentExecutive")
                return OrganizationType.GovernmentExecutive;
            if (type == "LocalGovernment")
                return OrganizationType.LocalGovernment;
            if (type == "Shelter")
                return OrganizationType.Shelter;
            if (type == "Trapping")
                return OrganizationType.Trapping;
            if (type == "TrappingAndShelter")
                return OrganizationType.TrappingAndShelter;
            if (type == "Transportation")
                return OrganizationType.Transportation;
            if (type == "VetClinicState")
                return OrganizationType.VetClinicState;
            if (type == "VetClinicMunicipal")
                return OrganizationType.VetClinicMunicipal;
            if (type == "VetClinicPrivate")
                return OrganizationType.VetClinicPrivate;
            if (type == "CharityFoundation")
                return OrganizationType.CharityFoundation;
            if (type == "AnimalGoodsSeller")
                return OrganizationType.AnimalGoodsSeller;
            if (type == "Applicant")
                return OrganizationType.Applicant;
            return OrganizationType.DirectoryValues;

        }
        public int idOrg { get; set; }

        [Filterable("namee")]
        public string name { get; set; }

        [Filterable("inn")]
        public string INN { get; set; }

        [Filterable("kpp")]
        public string KPP { get; set; }

        [Filterable("registration")]
        public Location registrationAdress { get; set; }

        [Filterable("typee")]
        public OrganizationType type { get; set; }
        public string status { get; set; }

        public Organization(int IdOrg, string name, string iNN, string kPP,
            Location registrationAdress, OrganizationType type, string status)
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
            var registrationAdress = reader.GetInt32(reader.GetOrdinal("registration"));
            var type = reader.GetString(reader.GetOrdinal("typee"));
            var status = reader.GetString(reader.GetOrdinal("status"));

            reader.Close();
            if (!connectionAlreadyOpen)
                cn.Close();

            return new Organization(id, name, inn, kpp,
                Location.GetById(registrationAdress, cn, connectionAlreadyOpen), StringToEnum(type), status);
        }
    }
}
